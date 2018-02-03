var SnappetChallenge;
(function (SnappetChallenge) {
    var ProgressVM = /** @class */ (function () {
        function ProgressVM(progress) {
            this.progress = progress;
            var maxProgress = 30;
            var absoluteProgress = Math.abs(progress);
            var boundedProgress = Math.min(maxProgress, absoluteProgress);
            this.progressBarWidth = boundedProgress / maxProgress * 100;
            this.isNegative = progress < 0;
            this.formattedValue = (((progress * 100) | 0) / 100).toString();
        }
        return ProgressVM;
    }());
    SnappetChallenge.ProgressVM = ProgressVM;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=progressVM.js.map