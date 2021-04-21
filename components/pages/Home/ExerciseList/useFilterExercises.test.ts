import { act } from '@testing-library/react';
import { renderHook } from '@testing-library/react-hooks';

import useFilterExercises from './useFilterExercises';
import { Exercise } from '@lib/models/Exercise';
import { testList } from '@lib/testUtils';

describe('useFilterExercises', () => {
  beforeAll(() => {
    jest.useFakeTimers();
  });

  it('return the unfiltered list by default', () => {
    const list = [{}, {}, {}] as Exercise[];

    const { result } = renderHook(() => useFilterExercises(list, '', -1));

    expect(result.current).toEqual(list);
  });

  it('filter by search term - UserId', () => {
    const expectedItem = testList[0];
    const { result } = renderHook(() =>
      useFilterExercises(testList, expectedItem.UserId.toString(), -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(1);
    expect(result.current[0]).toEqual(expectedItem);
  });

  it('filter by search term - ExerciseId', () => {
    const expectedItem = testList[0];
    const { result } = renderHook(() =>
      useFilterExercises(testList, expectedItem.ExerciseId.toString(), -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(1);
    expect(result.current[0]).toEqual(expectedItem);
  });

  it('filter by search term - Domain', () => {
    const domain = 'Domain Test 1';
    const expectedItems = testList.filter((item) => item.Domain === domain);

    const { result } = renderHook(() =>
      useFilterExercises(testList, domain, -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(expectedItems.length);
    expect(result.current).toEqual(expectedItems);
  });

  it('filter by search term - Subject', () => {
    const subject = 'Subject Test 1';
    const expectedItems = testList.filter((item) => item.Subject === subject);

    const { result } = renderHook(() =>
      useFilterExercises(testList, subject, -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(expectedItems.length);
    expect(result.current).toEqual(expectedItems);
  });

  it('filter by search term - LearningObjective', () => {
    const learningObjective = 'Learning Objective 1';
    const expectedItems = testList.filter(
      (item) => item.LearningObjective === learningObjective,
    );

    const { result } = renderHook(() =>
      useFilterExercises(testList, learningObjective, -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(expectedItems.length);
    expect(result.current).toEqual(expectedItems);
  });

  it('filter by search term - any', () => {
    const { result } = renderHook(() =>
      useFilterExercises(testList, 'test', -1),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(testList.length);
    expect(result.current).toEqual(testList);
  });

  it('filter by Correct', () => {
    const correct = 1;
    const expectedItems = testList.filter((item) => item.Correct === correct);

    const { result } = renderHook(() =>
      useFilterExercises(testList, '', correct),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(expectedItems.length);
    expect(result.current).toEqual(expectedItems);
  });

  it('filter combined', () => {
    const searchTerm = 'Subject Test 1';
    const correct = 1;
    const expectedItem = testList[0];

    const { result } = renderHook(() =>
      useFilterExercises(testList, searchTerm, correct),
    );
    act(() => {
      jest.advanceTimersByTime(1000);
    });

    expect(result.current).toHaveLength(1);
    expect(result.current[0]).toEqual(expectedItem);
  });
});
