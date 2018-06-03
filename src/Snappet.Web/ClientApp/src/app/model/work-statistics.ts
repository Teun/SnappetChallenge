export class WorkStatistics {
  totalAnswers = 0;
  totalCorrect = 0;
  totalProgress = 0;
  totalExercises = 0;
  averageDifficulty = 0;
}

export class WorkStatisticsByTopic extends WorkStatistics {
  subject: string;
  domain: string;
  learningObjective: string;
}

export class WorkStatisticsTree extends WorkStatistics {
  name: string;
  children: WorkStatisticsTree[];
}
