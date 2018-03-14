'use strict'

var fs= require("fs");
var express = require( 'express' );
var app = express();
var cache = null;
function yyyymmdd(date) {
    var mm = date.getMonth() + 1; // getMonth() is zero-based
    var dd = date.getDate();
  
    return [date.getFullYear(),
            (mm>9 ? '' : '0') + mm,
            (dd>9 ? '' : '0') + dd
           ].join('');
};

app.use( express.static('./app') );
app.use( express.static('./node_modules') );


app.get( '/studentsData', function( req, res ) {
    var now = '2015-03-24T11:30:000';
    if(cache){
        var fData = cache.filter(d => d.SubmitDateTime.startsWith('2015-03-24') && d.SubmitDateTime <= now);
        res.status(200).send(fData);
    }
    else{
        fs.readFile('./Data/work.json', 'utf8', function (err, data) {
        if (err) 
        res.status(500).send('Server error!')      
        var cache = JSON.parse(data);
        var fData = cache.filter(d => d.SubmitDateTime.startsWith('2015-03-24') && d.SubmitDateTime <= now);
        res.status(200).send(fData);
})}});
    


app.get( '/', function( req, res ) {
  
  res.sendFile( __dirname + '/index.html');
  
});

var server = app.listen( 8000, function() {
  console.log( 'server started. listening to 8000' );
})