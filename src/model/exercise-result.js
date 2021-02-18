import {LocalDateTime} from 'js-joda';

export const CollectionName = 'exercise-results';

const create = ({
  SubmittedAnswerId,
  SubmitDateTime,
  Correct,
  Progress,
  UserId,
  ExerciseId,
  Difficulty,
  Subject,
  Domain,
  LearningObjective,
}) => ({
  SubmittedAnswerId: parseInt(SubmittedAnswerId, 10),
  SubmitDateTime: LocalDateTime.parse(SubmitDateTime),
  Correct: Boolean(Correct),
  Progress: parseInt(Progress, 10),
  UserId: parseInt(UserId, 10),
  ExerciseId: parseInt(ExerciseId, 10),
  Difficulty: parseFloat(Difficulty),
  Subject: String(Subject),
  Domain: String(Domain),
  LearningObjective: String(LearningObjective),
});

export default create;
