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
  submittedAnswerId: parseInt(SubmittedAnswerId, 10),
  submitDateTime: new Date(SubmitDateTime),
  correct: Boolean(Correct),
  progress: parseInt(Progress, 10),
  userId: parseInt(UserId, 10),
  exerciseId: parseInt(ExerciseId, 10) || 0,
  difficulty: parseFloat(Difficulty) || 0,
  subject: String(Subject),
  domain: String(Domain),
  learningObjective: String(LearningObjective),
});

export default create;
