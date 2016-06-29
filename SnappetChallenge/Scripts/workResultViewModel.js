define(['knockout', 'jquery'], function (ko, $) {
    return function WorkResult(data) {
        var result = this;
        result.userId = ko.observable(data.UserId);
        result.answers = ko.observableArray(data.Answers);
        result.correctColor = ko.computed(function () {
            // Give each student a color: green is good, red is many wrong answers
            var correct = correctAnswers();
            var total = result.answers().length;
            var ratio = correct / total;
            var green = ratio * 255;
            var red = 255 - (ratio * 255);
            return 'rgb(' + red.toFixed(0) + ', ' + green.toFixed(0) + ', 0)';
        });
        result.totalCorrect = ko.computed(function () {
            return correctAnswers();
        });

        function correctAnswers() {
            // Add up all the correct answers.
            return result.answers().reduce(addCorrect, 0);
        }

        function addCorrect(a, b) {
            // Add this answer to the previous ones, i made a check here to only count 1 correctly, there were some 3's in the data?).
            return a + (b.Correct === 1 ? 1 : 0);
        }
    }
});
