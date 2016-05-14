$(document).ready(function () {

	$("#TimePeriod").change(function () {
		WorkData.LoadSubjects();
		return false;
	});

	$("#Subject").change(function () {
		WorkData.LoadDomains();
		return false;
	});

	$("#Domain").change(function () {
		WorkData.LoadLearningObjectives();
		return false;
	});

	$("#LearningObjective").change(function () {
		WorkData.LoadAnswerStatistics();
		return false;
	});
	WorkData.LoadSubjects();
});

var WorkData = {
	AnswersPerDayChart: null,
	PercentCorrectPerDayChart: null,
	PercentCorrectPerStudentChart: null,
	ProgressPerStudentChart: null,
	AverageDifficultyPerStudentChart: null,
	StudentsWithAnswersPerDayChart: null,
	AnswerBreakdownChart: null,

	LoadSubjects: function () {
		$("#Subject").empty();
		$.ajax({
			type: 'POST',
			url: '/WorkData/GetSubjects',
			dataType: 'json',
			data: { timePeriod: $("#TimePeriod").val() },
			success: function (subjects) {
				$.each(subjects, function (i, subject) {
					$("#Subject").append('<option value="' + subject.Value + '">' + subject.Text + '</option>');
				});
				WorkData.LoadDomains();
			},
			error: function (ex) {
				alert('Vakken kon niet geladen worden.' + ex);
			}
		});
	},

	LoadDomains: function () {
		$("#Domain").empty();
		$.ajax({
			type: 'POST',
			url: '/WorkData/GetDomains',
			dataType: 'json',
			data: { timePeriod: $("#TimePeriod").val(), subject: $('#Subject').val() },
			success: function (domains) {
				$.each(domains, function (i, domain) {
					$("#Domain").append('<option value="' + domain.Value + '">' + domain.Text + '</option>');
				});
				WorkData.LoadLearningObjectives();
			},
			error: function (ex) {
				alert('Domeinen kon niet geladen worden.' + ex);
			}
		});
	},

	LoadLearningObjectives: function () {
		$("#LearningObjective").empty();
		$.ajax({
			type: 'POST',
			url: '/WorkData/GetLearningObjectives',
			dataType: 'json',
			data: { timePeriod: $("#TimePeriod").val(), subject: $('#Subject').val(), domain: $('#Domain').val() },
			success: function (learningObjectives) {
				$.each(learningObjectives, function (i, learningObjective) {
					$("#LearningObjective").append('<option value="' + learningObjective.Value + '">' + learningObjective.Text + '</option>');
				});
				WorkData.LoadAnswerStatistics();
			},
			error: function (ex) {
				alert('Leerdoelen kon niet geladen worden.' + ex);
			}
		});
	},

	LoadAnswerStatistics: function () {
		$.ajax({
			type: 'POST',
			url: '/WorkData/GetAnswerStatistics',
			dataType: 'json',
			data: { timePeriod: $("#TimePeriod").val(), subject: $('#Subject').val(), domain: $('#Domain').val(), learningObjective: $('#LearningObjective').val() },
			success: function (statistics) {
				WorkData.UpdateStatisticsData(statistics);
			},
			error: function (ex) {
				alert('Statistieken kon niet geladen worden.' + ex);
			}
		});

	},

	UpdateStatisticsData: function (statistics) {
		$('#numberOfStudents').html(statistics.numberOfStudents);
		$('#numberOfAnswers').html(statistics.numberOfAnswers);
		$('#numberOfCorrectAnswers').html(statistics.numberOfCorrectAnswers);
		$('#percentCorrectAnswers').html(statistics.percentCorrectAnswers.toFixed(2));
		$('#averageAnswersPerStudent').html(statistics.averageAnswersPerStudent.toFixed(2));
		$('#averageCorrectAnswersPerStudent').html(statistics.averageCorrectAnswersPerStudent.toFixed(2));
		$('#highestDifficulty').html(statistics.highestDifficulty.toFixed(2));
		$('#lowestDifficulty').html(statistics.lowestDifficulty.toFixed(2));
		$('#averageDifficulty').html(statistics.averageDifficulty.toFixed(2));

		var answersPerStudentPerDayContext = $("#answersPerStudentPerDayChart");
		if (WorkData.AnswersPerStudentPerDayChart != null)
			WorkData.AnswersPerStudentPerDayChart.destroy();

		WorkData.AnswersPerStudentPerDayChart = new Chart(answersPerStudentPerDayContext, {
			type: 'bar',
			data: {
				labels: statistics.answersPerStudentPerDayData.Labels,
				datasets: [{
					label: statistics.answersPerStudentPerDayData.ValueLabel,
					data: statistics.answersPerStudentPerDayData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var percentCorrectPerDayContext = $("#percentCorrectPerDayChart");
		if (WorkData.PercentCorrectPerDayChart != null)
			WorkData.PercentCorrectPerDayChart.destroy();

		WorkData.PercentCorrectPerDayChart = new Chart(percentCorrectPerDayContext, {
			type: 'bar',
			data: {
				labels: statistics.percentCorrectPerDayData.Labels,
				datasets: [{
					label: statistics.percentCorrectPerDayData.ValueLabel,
					data: statistics.percentCorrectPerDayData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var percentCorrectPerStudentContext = $("#percentCorrectPerStudentChart");
		if (WorkData.PercentCorrectPerStudentChart != null)
			WorkData.PercentCorrectPerStudentChart.destroy();

		WorkData.PercentCorrectPerStudentChart = new Chart(percentCorrectPerStudentContext, {
			type: 'bar',
			data: {
				labels: statistics.percentCorrectPerStudentData.Labels,
				datasets: [{
					label: statistics.percentCorrectPerStudentData.ValueLabel,
					data: statistics.percentCorrectPerStudentData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var progressPerStudentContext = $("#progressPerStudentChart");
		if (WorkData.ProgressPerStudentChart != null)
			WorkData.ProgressPerStudentChart.destroy();

		WorkData.ProgressPerStudentChart = new Chart(progressPerStudentContext, {
			type: 'bar',
			data: {
				labels: statistics.progressPerStudentData.Labels,
				datasets: [{
					label: statistics.progressPerStudentData.ValueLabel,
					data: statistics.progressPerStudentData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var averageDifficultyPerStudentContext = $("#averageDifficultyPerStudentChart");
		if (WorkData.AverageDifficultyPerStudentChart != null)
			WorkData.AverageDifficultyPerStudentChart.destroy();

		WorkData.AverageDifficultyPerStudentChart = new Chart(averageDifficultyPerStudentContext, {
			type: 'bar',
			data: {
				labels: statistics.averageDifficultyPerStudentData.Labels,
				datasets: [{
					label: statistics.averageDifficultyPerStudentData.ValueLabel,
					data: statistics.averageDifficultyPerStudentData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var studentsWithAnswersPerDayContext = $("#studentsWithAnswersPerDayChart");
		if (WorkData.StudentsWithAnswersPerDayChart != null)
			WorkData.StudentsWithAnswersPerDayChart.destroy();

		WorkData.StudentsWithAnswersPerDayChart = new Chart(studentsWithAnswersPerDayContext, {
			type: 'bar',
			data: {
				labels: statistics.studentsWithAnswersPerDayData.Labels,
				datasets: [{
					label: statistics.studentsWithAnswersPerDayData.ValueLabel,
					data: statistics.studentsWithAnswersPerDayData.Values
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});

		var answerBreakdownContext = $("#answerBreakdownChart");
		if (WorkData.AnswerBreakdownChart != null)
			WorkData.AnswerBreakdownChart.destroy();
		$("#answerBreakdownHeading").html(statistics.answerBreakdownData.ValueLabel);
		WorkData.AnswerBreakdownChart = new Chart(answerBreakdownContext, {
			type: 'pie',
			data: {
				labels: statistics.answerBreakdownData.Labels,
				datasets: [{
					data: statistics.answerBreakdownData.Values,
					backgroundColor: statistics.answerBreakdownData.Colors,
					hoverBackgroundColor: statistics.answerBreakdownData.HoverColors 
				}]
			},
			options: {
				
			}
		});

	}
}

