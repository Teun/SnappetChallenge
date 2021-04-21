import React, { useState } from 'react';
import styled from '@emotion/styled';
import { Grid, MenuItem, TextField } from '@material-ui/core';

import { Exercise } from '@lib/models/Exercise';
import List from './List';
import useFilterExercises from './useFilterExercises';

interface ExerciseListProps {
  exercises: Exercise[];
}

const ExerciseList: React.FC<ExerciseListProps> = ({ exercises }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const [correctAnswer, setCorrectAnswer] = useState(-1);

  const filteredExercises = useFilterExercises(exercises, searchTerm, correctAnswer);

  return (
    <Container>
      <SearchContainer container spacing={2} justify="center">
        <Grid item xs={12} sm={8} md={6}>
          <TextField
            value={searchTerm}
            onChange={(event) => setSearchTerm(event.target.value)}
            label="Search"
            helperText="Student number, exercise number, domain, subject or learning objective"
            variant="outlined"
            size="small"
            fullWidth
          />
        </Grid>
        <Grid item xs={12} sm={4} md={2}>
          <TextField
            select
            value={correctAnswer}
            onChange={(event) => setCorrectAnswer(parseInt(event.target.value))}
            label="Correct answer"
            variant="outlined"
            size="small"
            fullWidth
          >
            <MenuItem value={-1}>Any</MenuItem>
            <MenuItem value={1}>Yes</MenuItem>
            <MenuItem value={0}>No</MenuItem>
          </TextField>
        </Grid>
      </SearchContainer>

      <List exercises={filteredExercises} />
    </Container>
  );
};

export default ExerciseList;

const Container = styled.div`
  flex: 1;
  width: 100%;

  display: flex;
  flex-direction: column;
`;

const SearchContainer = styled(Grid)`
  max-width: 100vw;
  padding: ${({ theme }) => theme.spacing(2)}px;
`;
