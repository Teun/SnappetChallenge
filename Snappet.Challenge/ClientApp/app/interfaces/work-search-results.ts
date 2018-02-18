import { WorkItem } from './work-item';

export interface WorkSearchResults {
    totalCount: number;
    pagesCount: number;
    correctRate: number;
    avgProgress: number;
    workItems: WorkItem[];
}