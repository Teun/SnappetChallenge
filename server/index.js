const express = require('express');
const fs = require('fs').promises;
const cors = require('cors');
const app = express();
const port = 3000;

app.use(cors());

app.get('/overview', async (req, res) => {
    fs.readFile('data/work.json')
        .then((jsonData) => {
            const endDate = new Date('2015-03-24 11:30:00');
            const filteredData = JSON.parse(jsonData).filter(el => new Date(el.SubmitDateTime) <= endDate);
            res.send(filteredData);
        })
        .catch(() => {
            res.status(500).send('Could not load data');
        });
});

app.get('/students', async (req, res) => {
    fs.readFile('data/students.json')
        .then((jsonData) => {
            const data = JSON.parse(jsonData)
            res.send(data);
        })
        .catch(() => {
            res.status(500).send('Could not load students');
        });
})

app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`);
});
