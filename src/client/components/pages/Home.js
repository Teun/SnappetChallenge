import React, {useEffect} from 'react';
import t from 'prop-types';
import {Typography, TextField as MuiTextField} from '@material-ui/core';
import {DataGrid} from '@material-ui/data-grid';
import {Check, Close} from '@material-ui/icons';
import {useDispatch, useSelector} from 'react-redux';
import {createSelector} from 'reselect';
import {assoc, map, prop, uniq, view} from 'ramda';
import styled from 'styled-components';

import Page from '../template/Page';
import View from '../atoms/View';
import GradientBar from '../molecules/GradientBar';
import {
  exerciseResultsState, dateFromState, dateToState
} from '../../redux/reducers/exercises-results';
import {getExercisesResults, setDateFrom, setDateTo} from '../../redux/actions/exercises-results';
import {isLoadingState} from '../../redux/reducers/ui';
import theme from '../../theme';
import {UTCtoLocaleString, localeToUTC} from '../../utils/date';

const getProgress = p => p < 0 ? 0 : p;

const TextField = styled(MuiTextField)`
  margin: 0 ${theme.spacing(2)}px;
`;

const CheckIcon = styled(Check)`
  color: green;
`;

const CloseIcon = styled(Close)`
  color: red;
`;

const ActionsContainer = styled(View)`
  max-height: 100px;
`;

const Summary = styled.div`
  padding: ${theme.spacing(2)}px;
`;

const columns = [
  {
    field: 'submitDateTime',
    headerName: 'Submit DateTime',
    width: 240,
    renderCell: params => <span alt={params.value}>{new Date(params.value).toLocaleString()}</span>,
  },
  {
    field: 'userId',
    headerName: 'User',
    width: 120,
  },
  {
    field: 'exerciseId',
    headerName: 'Exercise',
    width: 120,
  },
  {
    field: 'submittedAnswerId',
    headerName: 'Answer',
    width: 120,
  },
  {
    field: 'domain',
    headerName: 'Domain',
    flex: 1,
    sortable: true,
  },
  {
    field: 'subject',
    headerName: 'Subject',
    flex: 1,
    sortable: true,
  },
  {
    field: 'learningObjective',
    headerName: 'Learning Objective',
    sortable: true,
    width: 300,
    renderCell: params => <span alt={params.value}>{params.value}</span>,
  },
  {
    field: 'correct',
    headerName: 'Correct',
    sortable: true,
    align: 'center',
    renderCell: params => params.value ? <CheckIcon /> : <CloseIcon />,
  },
  {
    field: 'progress',
    headerName: 'Progress',
    flex: 1,
    sortable: true,
    renderCell: params =>
      <GradientBar maximun={100} current={getProgress(params.value)} />,
  },
  {
    field: 'difficulty',
    headerName: 'Difficulty',
    flex: 1,
    sortable: true,
    renderCell: params =>
      <GradientBar maximun={1000} current={getProgress(params.value)} />,
  },
];

// TODO: Reduce the amount of responsibility of this component
const Home = ({
  items, dateFrom, dateTo, data, loading, onDateFromChange, onDateToChange
}) => (
  <Page title="Report">
    <ActionsContainer>
      <Typography>Hey Professor! Select a date interval to check your class scores!</Typography>
      <View flexDirection="row">
        <TextField
          id="datetime-from"
          label="From"
          type="datetime-local"
          defaultValue={dateFrom}
          onChange={e => onDateFromChange(e.target.value)}
          InputLabelProps={{
            shrink: true,
          }}
        />
        <TextField
          id="datetime-to"
          label="To"
          type="datetime-local"
          onChange={e => onDateToChange(e.target.value)}
          defaultValue={dateTo}
          InputLabelProps={{
            shrink: true,
          }}
        />
      </View>
    </ActionsContainer>
    <Summary id="summary">
      <Typography variant="body1">Total of correct answers: {data.totalCorrectAnswers}</Typography>
      <Typography variant="body1">Total of students: {data.totalStudents}</Typography>
      <Typography variant="body1">Total of exercises: {data.totalExercises}</Typography>
    </Summary>

    <View flex="1" alignItems="stretch">
      <DataGrid loading={loading} rows={items} columns={columns} pageSize={50} />
    </View>
  </Page>
);

Home.propTypes = {
  onDateFromChange: t.func,
  onDateToChange: t.func,
  loading: t.bool,
  dateFrom: t.string,
  dateTo: t.string,
  data: t.shape({
    totalCorrectAnswers: t.number,
    totalStudents: t.number,
    totalExercises: t.number,
  }),
  items: t.arrayOf(t.shape({
    _id: t.string,
    submittedAnswerId: t.number,
    submitDateTime: t.string,
    correct: t.bool,
    progress: t.number,
    userId: t.number,
    exerciseId: t.number,
    difficult: t.number,
    subject: t.string,
    domain: t.string,
    learningObjective: t.string
  }))
};

// TODO: Extract to a separate folder and test each selector
const exercisesSelector = createSelector(
  [view(exerciseResultsState)],
  map(r => assoc('id', r._id, r))
);
const dateFromSelector = createSelector([view(dateFromState)], UTCtoLocaleString);
const dateToSelector = createSelector([view(dateToState)], UTCtoLocaleString);
const loadingSelector = createSelector([view(isLoadingState)], Boolean);
const dataSeletor = createSelector(
  [exercisesSelector],
  exercises => ({
    totalCorrectAnswers: exercises.filter(prop('correct')).length,
    totalStudents: uniq(exercises.map(prop('userId'))).length,
    totalExercises: uniq(exercises.map(prop('exerciseId'))).length
  })
);

export default () => {
  const dispatch = useDispatch();
  const rows = useSelector(exercisesSelector);
  const from = useSelector(dateFromSelector);
  const to = useSelector(dateToSelector);
  const loading = useSelector(loadingSelector);
  const data = useSelector(dataSeletor);

  const onDateFromChangeHandler = value => dispatch(setDateFrom(localeToUTC(value)));
  const onDateToChangeHandler = value => dispatch(setDateTo(localeToUTC(value)));

  useEffect(() => {
    if (localeToUTC(from) && localeToUTC(to)) {
      dispatch(getExercisesResults({from: localeToUTC(from), to: localeToUTC(to)}));
    }
    return () => { };
  }, [dispatch, from, to]);

  return (
    <Home
      onDateFromChange={onDateFromChangeHandler}
      onDateToChange={onDateToChangeHandler}
      items={rows}
      dateFrom={from}
      dateTo={to}
      data={data}
      loading={loading} />
  );
};
