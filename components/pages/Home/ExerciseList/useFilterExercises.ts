import { Exercise } from '@lib/models/Exercise';
import { useState } from 'react';
import { useDebounce } from 'react-use';

const DEBOUNCE_TIME = 1000;

const useFilterExercises = (
  exercises: Exercise[],
  searchTerm: string,
  correctAnswer: number,
) => {
  const [filteredExercises, setFilteredExercises] = useState(exercises);

  useDebounce(
    () => {
      if (searchTerm.length === 0 && correctAnswer === null) {
        setFilteredExercises(exercises);
        return;
      }

      const filteredItems = exercises.filter(
        filterItem(searchTerm.toLowerCase(), correctAnswer),
      );

      setFilteredExercises(filteredItems);
    },
    DEBOUNCE_TIME,
    [searchTerm, correctAnswer],
  );

  return filteredExercises;
};

export default useFilterExercises;

const filterItem = (searchTerm: string, correctAnswer?: number) => (
  item: Exercise,
) => {
  const search =
    item.UserId.toString().toLowerCase().includes(searchTerm) ||
    item.ExerciseId.toString().toLowerCase().includes(searchTerm) ||
    item.Domain.toLowerCase().includes(searchTerm) ||
    item.Subject.toLowerCase().includes(searchTerm) ||
    item.LearningObjective.toLowerCase().includes(searchTerm);

  const correct = correctAnswer === -1 ? true : item.Correct === correctAnswer;

  return search && correct;
};
