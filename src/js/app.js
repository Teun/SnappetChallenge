

// Class to represent a row in the seat reservations grid
function StudentProgress(studentObject) {
    var context = this;
    context.answerCount = studentObject.AnswerCount;
    context.answerCount = studentObject.AnswerCount;
    context.correctCount = studentObject.CorrectCount;
    context.totalProgress = studentObject.TotalProgress;
    context.totalDifficulty = studentObject.TotalDifficulty;
    context.userId = studentObject.UserId;
    context.averageDifficulty = studentObject.AverageDifficulty;

    context.correctnessPercentage = studentObject.CorrectnessPercentage;

    context.relativeCorectnessPercentage = studentObject.RelativeCorectnessPercentage;
    context.relativeAnswerCountPercentage = studentObject.RelativeAnswerCountPercentage;
    context.relativeCorrectCountPercentage = studentObject.RelativeCorrectCountPercentage;

}

// Overall viewmodel for this screen, along with initial state
function ClassProgressModel() {
    var context = this;

    // Non-editable catalog data - would come from the server
    context.studentProgress = totals;

    // Editable data
    context.classProgress = ko.observableArray(context.studentProgress.map(function(student){
            return new StudentProgress(student);
        })
    );

    // Operations
    // self.addSeat = function() {
    //     self.seats.push(new SeatReservation("", self.availableMeals[0]));
    // };
    // self.removeSeat = function(seat) {
    //     self.seats.remove(seat);
    // };

    // self.totalSurcharge = ko.computed(function() {
    //    var total = 0;
    //    for (var i = 0; i < self.seats().length; i++)
    //        total += self.seats()[i].meal().price;
    //    return total;
    // });
}

ko.applyBindings(new ClassProgressModel());
