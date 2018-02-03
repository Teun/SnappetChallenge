module SnappetChallenge {
    export class ProgressVM {
        progressBarWidth: number;
        isNegative: boolean;
        formattedValue: string;

        constructor(public progress: number) {
            const maxProgress = 30;
            const absoluteProgress = Math.abs(progress);
            const boundedProgress = Math.min(maxProgress, absoluteProgress);
            this.progressBarWidth = boundedProgress / maxProgress * 100;
            this.isNegative = progress < 0;
            this.formattedValue = (((progress * 100) | 0) / 100).toString();
        }
    }
}