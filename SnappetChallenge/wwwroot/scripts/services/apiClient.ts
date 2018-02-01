module SnappetChallenge {
    import LearningObjective = Models.LearningObjective;
    import DateRangeFilter = Models.DateRangeFilter;
    import User = Models.User;
    import UserDetails = Models.UserDetails;

    export interface IApiClient {
        getLearningObjectives: (dateRangeFilter: DateRangeFilter, callback: (data: LearningObjective[]) => void) => JQueryXHR;
        getUsers: (dateRangeFilter: DateRangeFilter, callback: (data: User[]) => void) => JQueryXHR;
        getUserDetails: (userId: number, dateRangeFilter: DateRangeFilter, callback: (data: UserDetails) => void) => JQueryXHR;
    }

    export class ApiClient implements IApiClient {
        getLearningObjectives: (dateRangeFilter: DateRangeFilter, callback: (data: LearningObjective[]) => void) => JQueryXHR;
        getUsers: (dateRangeFilter: DateRangeFilter, callback: (data: User[]) => void) => JQueryXHR;
        getUserDetails: (userId: number, dateRangeFilter: DateRangeFilter, callback: (data: UserDetails) => void) => JQueryXHR;

        constructor(private readonly httpClient: IHttpClient, private readonly apiUrlConfig: ApiUrlConfig) {
            this.getLearningObjectives = (dateRangeFilter: DateRangeFilter, callback: (data: LearningObjective[]) => void) => {
                return httpClient.get(apiUrlConfig.learningObjectivesUrl, dateRangeFilter, callback);
            }

            this.getUsers = (dateRangeFilter: DateRangeFilter, callback: (data: User[]) => void) => {
                return httpClient.get(apiUrlConfig.usersUrl, dateRangeFilter, callback);
            }

            this.getUserDetails = (userId: number,
                dateRangeFilter: DateRangeFilter,
                callback: (data: UserDetails) => void) => {
                return httpClient.get(apiUrlConfig.usersUrl + "/" + userId, dateRangeFilter, callback);
            }
        }
    }
}