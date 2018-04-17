/*
* This template uses the TsT - Typewriter.
* Read more at :
* -- https://github.com/frhagn/Typewriter (Github)
* -- https://marketplace.visualstudio.com/items?itemName=frhagn.Typewriter  (Extension of Visual Studio 17)
* -- http://frhagn.github.io/Typewriter/ (Documentation)
*/

/* tslint:disable*/

declare namespace Nicollas.Dto {

	interface evaluationDto  { 
        submittedAnswerId: number;
        submitDateTime: Date;
        correct: boolean;
        progress: number;
        userId: number;
        exerciseId: number;
        difficulty: string;
        subject: string;
        domain: string;
        learningObjective: string;
    }
}