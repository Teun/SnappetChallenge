export interface WorkQuery {
    subject: string | null;
    domain: string | null;
    learningObjective: string | null;
    correct: boolean | null;
    user: number | null;
    exercise: number | null;
    dateSubmitted: Date | null;
    clientTimeZoneOffset: number;
    pageNumber: number;
    itemsPerPage: number;
}