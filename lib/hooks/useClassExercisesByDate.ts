import useSWR from 'swr';

import { Exercise } from '@lib/models/Exercise';

const fetchClassExercisesByDate = (date: Date) => async () => {
  const response = await fetch(`/api/classes/exercises?date=${date.toISOString()}`);
  return response.json();
};

interface ClassExercises {
  exercises?: Exercise[];
  isLoading: boolean;
  isError?: Error;
}

const useClassExercisesByDate = (date: Date): ClassExercises => {
  const { data, error } = useSWR(
    'classes/exercises',
    fetchClassExercisesByDate(date),
  );

  return {
    exercises: data,
    isLoading: !error && !data,
    isError: error
  }
};

export default useClassExercisesByDate;
