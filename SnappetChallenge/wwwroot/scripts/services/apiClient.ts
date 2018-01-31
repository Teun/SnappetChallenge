﻿module SnappetChallenge {
    import LearningObjective = Models.LearningObjective;


    export interface IApiClient {
        getLearningObjectives: (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => JQueryXHR;
    }

    export class ApiClient implements IApiClient {
        getLearningObjectives: (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => JQueryXHR;

        constructor(private httpClient: IHttpClient, private apiUriConfig: ApiUriConfig) {
            this.getLearningObjectives = (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => {
                return httpClient.get(apiUriConfig.learningObjectivesUri,
                    {
                        from: moment(from).format("YYYY-MM-DDTHH:mm:ss[Z]"),
                        to: moment(to).format("YYYY-MM-DDTHH:mm:ss[Z]")
                    }, callback);
            }
        }
    }
}