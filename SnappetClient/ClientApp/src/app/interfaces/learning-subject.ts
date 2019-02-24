import { LearningDomain } from './learning-domain';

export interface LearningSubject {
    name: string,
    domains: LearningDomain[]
}
