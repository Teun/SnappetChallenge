import React from 'react';
import { render } from '@testing-library/react';

import ListItem from './ListItem';

describe('ListItem', () => {
  it('matches snapshot', () => {
    const exercise = {
      SubmittedAnswerId: 2628622,
      SubmitDateTime: '2015-03-02T08:23:45.070',
      Correct: 1,
      Progress: 2,
      UserId: 40275,
      ExerciseId: 395191,
      Difficulty: '276.6952772',
      Subject: 'Subject Test 1',
      Domain: 'Domain Test 1',
      LearningObjective: 'Learning Objective 1',
    };

    const { container } = render(<ListItem exercise={exercise} />);
    expect(container).toMatchSnapshot();
  });
});
