import React from 'react';
import styled from '@emotion/styled';
import { Card, CardContent, Grid } from '@material-ui/core';
import { format } from 'date-fns/fp';

import { Exercise } from '@lib/models/Exercise';
import LabelValue from '@components/LabelValue';
import { fluidRange } from 'polished';

const formatDate = (date: string) => {
  const parsedDate = new Date(date);

  return format('dd/MM/yyyy HH:mm bb', parsedDate);
};

interface ListItemProps {
  exercise: Exercise;
}

const ListItem: React.FC<ListItemProps> = ({ exercise }) => {
  return (
    <Container>
      <CardContent>
        <Grid container>
          <LabelValue xs={12} label="Student" value={exercise.UserId} />

          <LabelValue
            xs={7}
            md={6}
            lg={7}
            label="Exercise"
            value={exercise.ExerciseId}
          />
          <LabelValue
            xs={5}
            md={6}
            lg={5}
            label="Correct"
            value={exercise.Correct == 1 ? 'Yes' : 'No'}
          />

          <LabelValue
            xs={7}
            md={6}
            lg={7}
            label="Difficulty"
            value={parseFloat(exercise.Difficulty).toFixed(2)}
          />
          <LabelValue
            xs={5}
            md={6}
            lg={5}
            label="Progress"
            value={exercise.Progress}
          />

          <LabelValue xs={12} md={6} lg={7} label="Domain" value={exercise.Domain} />
          <LabelValue xs={12} md={6} lg={5} label="Subject" value={exercise.Subject} />

          <LabelValue
            xs={12}
            label="Learning Objective"
            value={exercise.LearningObjective}
          />

          <LabelValue
            xs={12}
            md={6}
            lg={7}
            label="Submitted Answer"
            value={exercise.SubmittedAnswerId}
          />
          <LabelValue
            xs={12}
            md={6}
            lg={5}
            label="Submitted At"
            value={formatDate(exercise.SubmitDateTime)}
          />
        </Grid>
      </CardContent>
    </Container>
  );
};

export default ListItem;

const Container = styled(Card)`
  margin: 8px auto;

  display: flex;
  flex-direction: column;

  height: calc(100% - 16px);

  ${fluidRange({
    prop: 'width',
    fromSize: '312px',
    toSize: '656px',
  })};
`;
