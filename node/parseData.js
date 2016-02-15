var fs = require('fs');
var userIds = require('../Data/work.json');
var map = {};

var start = new Date(Date.UTC('2015','03','24','00','00','00','000'));
var end = new Date(Date.UTC('2015','03','24','11','30','00','000'));
var totals = [];

var mostAnswers = 0;
var mostCorrect = 0;
var highestPercentage = 0;

userIds.forEach(function(user){
    var timeArray = user.SubmitDateTime.split(/[-T.:]/);
    var time = new Date(Date.UTC.apply(null,timeArray));
    var userId = user.UserId;

    if( start < time && end > time){
        if(!map[userId]){
            map[userId] = [];
        }
        map[userId].push(user);
    }
});

function accumulate(collection){
    var acc = {
        AnswerCount: 0,
        CorrectCount: 0,
        TotalProgress: 0,
        TotalDifficulty: 0
    };

    collection.forEach(function(item){
        acc.AnswerCount++;
        acc.CorrectCount += item.Correct;
        acc.TotalProgress += item.Progress;
        var difficulty = Number(item.Difficulty);
        if(!isNaN(difficulty)){
            acc.TotalDifficulty += difficulty;
        }
    });


    acc.UserId = collection[0].UserId;
    acc.AverageDifficulty = acc.TotalDifficulty / acc.AnswerCount;
    acc.CorrectnessPercentage = Math.round( ( acc.CorrectCount / acc.AnswerCount ) * 10000 ) / 100;

    mostAnswers = Math.max( mostAnswers, acc.AnswerCount );
    mostCorrect = Math.max( mostCorrect, acc.CorrectCount );
    highestPercentage = Math.max( highestPercentage, acc.CorrectnessPercentage );

    return acc;
}

// inside we just assume no errors :)
fs.mkdir('parsed', function(){
    Object.keys(map).forEach(function(userId){
        var accumulated = accumulate(map[userId]);
        totals.push(accumulated);
        fs.writeFile( 'parsed/'+userId+'-raw.json', JSON.stringify(map[userId], null, '\t'), 'utf-8' );
        fs.writeFile( 'parsed/'+userId+'.json', JSON.stringify(accumulated, null, '\t'), 'utf-8' );
    });

    totals.forEach(function(item){
        item.RelativeCorectnessPercentage = Math.round( ( item.CorrectnessPercentage / highestPercentage ) * 10000 ) / 100;
        item.RelativeAnswerCountPercentage = Math.round( ( item.AnswerCount / mostAnswers ) * 10000 ) / 100;
        item.RelativeCorrectCountPercentage = Math.round( ( item.CorrectCount / mostCorrect ) * 10000 ) / 100;
    });
    fs.writeFile( 'parsed/totals.json', JSON.stringify(totals, null, '\t'), 'utf-8' );
    fs.mkdir('dist',function(){
        fs.writeFile( 'dist/totals.js', 'var totals = ' + JSON.stringify(totals, null, '\t') + ';', 'utf-8' );
    });
});



