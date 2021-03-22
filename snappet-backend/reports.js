const fs = require('fs');

// Returns overall subject based reports
const get_reports = function (filter) {
    let data = JSON.parse(fs.readFileSync('./work.json').toString());

    // it is 24th March, discard answers after that day.
    data = data.filter(value => value.SubmitDateTime.localeCompare('2015-03-25') < 0)
    if (filter && filter.student && filter.student.length > 0) {
        data = data.filter(value => filter.student.includes(value.UserId))
    }
    if (filter && filter.learning && filter.learning.length > 0) {
        data = data.filter(value => filter.learning.includes(value.LearningObjective))
    }
    if (filter && filter.subject && filter.subject.length > 0) {
        data = data.filter(value => filter.subject.includes(value.Subject))
    }
    if (filter && filter.beginDate && filter.endDate) {
        data = data.filter(value => value.SubmitDateTime.localeCompare(filter.beginDate) > 0 && value.SubmitDateTime.localeCompare(filter.endDate) < 0)
    }

    const subject_based = {}
    for (const answer of data) {
        if (!subject_based[answer.Subject]) {
            subject_based[answer.Subject] = [];
        }
        subject_based[answer.Subject].push(answer);
    }

    const learning_based = {}
    for (const answer of data) {
        if (!learning_based[answer.LearningObjective]) {
            learning_based[answer.LearningObjective] = [];
        }
        learning_based[answer.LearningObjective].push(answer);
    }

    const difficulties = [];
    for (const answer of data) {
        if (answer.Difficulty !== 'NULL') {
            difficulties.push(parseFloat(answer.Difficulty));
        }
    }
    const difficulty_based = {
        min: Math.min(...difficulties),
        max: Math.max(...difficulties),
        average: difficulties.reduce((previousValue, currentValue) => previousValue + currentValue, 0) / difficulties.length,
    };

    const reports = {
        subject: {
            answers: Object.keys(subject_based),
            count: Object.values(subject_based).map((x) => x.length)
        },
        learning: {
            answers: Object.keys(learning_based),
            count: Object.values(learning_based).map((x) => x.length)
        },
        difficulty: difficulty_based
    }
    return reports;
}

// Returns overall subject based reports of a specific student
const get_student_reports = function (uid) {
    const data = JSON.parse(fs.readFileSync('./work.json').toString());

    // it is 24th March, discard answers after that day.
    const student_data = data.filter(value => value.UserId === parseInt(uid) && value.SubmitDateTime.localeCompare('2015-03-25') < 0);

    const subject_based = {}
    for (const answer of student_data) {
        const day = answer.SubmitDateTime.split('T')[0];
        if (!subject_based[day]) {
            subject_based[day] = {};
        }
        if (!subject_based[day][answer.Subject]) {
            subject_based[day][answer.Subject] = [];
        }
        subject_based[day][answer.Subject].push(answer);
    }

    const learning_based = {}
    for (const answer of student_data) {
        const day = answer.SubmitDateTime.split('T')[0];
        if (!learning_based[day]) {
            learning_based[day] = {};
        }
        if (!learning_based[day][answer.LearningObjective]) {
            learning_based[day][answer.LearningObjective] = [];
        }
        learning_based[day][answer.LearningObjective].push(answer);
    }

    const progress = {
        subject: Object.keys(subject_based).map(day => {
            return Object.keys(subject_based[day]).map(subject => {
                return {
                    time: day,
                    subject: subject,
                    progress: subject_based[day][subject].reduce((acc, val) => acc + val.Progress, 0),
                    correct: subject_based[day][subject].reduce((acc, val) => acc + val.Correct, 0),
                    difficulty: subject_based[day][subject].reduce((acc, val) => {
                        if (val.Difficulty !== 'NULL') {
                            return acc + parseFloat(val.Difficulty);
                        }
                    }, 0) / subject_based[day][subject].length
                }
            })
        }),

        learning: Object.keys(learning_based).map(day => {
            return Object.keys(learning_based[day]).map(objective => {
                return {
                    time: day,
                    objective: objective,
                    progress: learning_based[day][objective].reduce((acc, val) => acc + val.Progress, 0),
                    correct: learning_based[day][objective].reduce((acc, val) => acc + val.Correct, 0),
                    difficulty: learning_based[day][objective].reduce((acc, val) => {
                        if (val.Difficulty !== 'NULL') {
                            return acc + parseFloat(val.Difficulty);
                        }
                    }, 0) / learning_based[day][objective].length
                }
            })
        }),

    }

    return progress;
}

const get_exercise_reports = function (time) {
    const data = JSON.parse(fs.readFileSync('./work.json').toString());

    // it is 24th March, discard answers after that day.
    const filtered_data = data.filter(value => value.SubmitDateTime.startsWith(time) && value.SubmitDateTime.localeCompare('2015-03-25') < 0);

    const exercise_data = {};
    for (const answer of filtered_data) {
        if (!exercise_data[answer.ExerciseId]) {
            exercise_data[answer.ExerciseId] = {};
        }
        if (!exercise_data[answer.ExerciseId][answer.UserId]) {
            exercise_data[answer.ExerciseId][answer.UserId] = [];
        }
        exercise_data[answer.ExerciseId][answer.UserId].push(answer);
    }

    const res = Object.keys(exercise_data).map(exercise_id => {
        return Object.keys(exercise_data[exercise_id]).map(user_id => {
            return {
                exercise_id: exercise_id,
                user_id: user_id,
                progress: exercise_data[exercise_id][user_id].reduce((acc, val) => acc + val.Progress, 0),
                correct: exercise_data[exercise_id][user_id].reduce((acc, val) => acc + val.Correct, 0),
                difficulty: exercise_data[exercise_id][user_id].reduce((acc, val) => {
                    if (val.Difficulty !== 'NULL') {
                        return acc + parseFloat(val.Difficulty);
                    }
                }, 0) / exercise_data[exercise_id][user_id].length
            }
        })
    });
    return res;
}


// Returns filter data for all reports
const get_filter_data = function () {
    const data = JSON.parse(fs.readFileSync('./work.json').toString());
    const res = {
        students: Array.from(new Set(data.map(value => value.UserId))),
        subjects: Array.from(new Set(data.map(value => value.Subject))),
        learnings: Array.from(new Set(data.map(value => value.LearningObjective)))
    };
    return res;
}

exports.get_reports = get_reports;
exports.get_filter_data = get_filter_data;
exports.get_student_reports = get_student_reports;
exports.get_exercise_reports = get_exercise_reports;
