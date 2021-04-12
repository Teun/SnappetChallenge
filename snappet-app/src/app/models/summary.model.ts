export class Summary {
    title: string='';
    totalProgress:number=0;
    totalAnswersSubmitted:number=0;
    totalCorrectAnswers:number=0;

    public get correctPercentage () {
        return Math.floor(this.totalCorrectAnswers/this.totalAnswersSubmitted * 100);
    }
}