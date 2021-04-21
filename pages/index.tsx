import Head from 'next/head';
import styled from '@emotion/styled';
import {
  AppBar,
  CircularProgress,
  Snackbar,
  Toolbar,
  Typography,
} from '@material-ui/core';
import Alert from '@material-ui/lab/Alert';
import AlertTitle from '@material-ui/lab/AlertTitle';

import useClassExercisesByDate from '@lib/hooks/useClassExercisesByDate';
import ExerciseList from '@components/pages/Home/ExerciseList';
import { fluidRange } from 'polished';

const Home = () => {
  const today = new Date('2015-03-24T11:30:00.000Z');
  const { exercises, isLoading, isError } = useClassExercisesByDate(today);

  return (
    <>
      <Head>
        <title>Exercises submitted today</title>
      </Head>

      <AppBar>
        <Toolbar>
          <Typography component="h1" variant="h6" color="inherit" noWrap>
            Exercises submitted today
          </Typography>
        </Toolbar>
      </AppBar>

      <Container>
        {isLoading && (
          <LoadingContainer>
            <CircularProgress />
          </LoadingContainer>
        )}

        {isError && (
          <Snackbar open autoHideDuration={6000}>
            <Alert severity="error">
              <AlertTitle>Error</AlertTitle>
              Something went wrong while loading the exercises.
              <br />
              <strong>Please try again.</strong>
            </Alert>
          </Snackbar>
        )}

        {exercises && <ExerciseList exercises={exercises} />}
      </Container>
    </>
  );
};

export default Home;

const Container = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;

  ${fluidRange({
    prop: 'paddingTop',
    fromSize: '56px',
    toSize: '64px',
  })};
`;

const LoadingContainer = styled.div`
  display: flex;
  flex: 1;
  align-items: center;
  justify-content: center;
`;
