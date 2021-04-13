import { BarChartModel } from './barchart';
import { PieChartModel } from './piechart';

export interface GraphData{
    objectiveChart: PieChartModel;
    subjectChart: PieChartModel;
    domainChart: PieChartModel;
    diffcultExcerciseChart: PieChartModel;
    topPerformerChart: BarChartModel;
    studentsFinishingDiffExcChart: BarChartModel;
}

