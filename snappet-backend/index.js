const express = require('express');
const cors = require('cors');
const app = express();
app.use(cors());
app.use(express.json());
const reports = require('./reports.js');

const port = 3000

app.get('/filter', (req, res) => {
    const answer = reports.get_filter_data();
    res.send({
        data: answer
    });
})

app.post('/reports', (req, res) => {
    const answer = reports.get_reports(req.body);
    res.send({
        data: answer
    });
})

app.get('/progress', (req, res) => {
    const answer = reports.get_student_reports(req.query.student_id);
    res.send({
        data: answer
    });
})

app.get('/exercise-reports', (req, res) => {
   const answer = reports.get_exercise_reports(req.query.time);
   res.send({
       data: answer
   })
});

app.listen(port, () => {
    console.log(`Snappet backend is running at http://localhost:${port}`)
})
