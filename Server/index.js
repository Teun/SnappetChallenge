const express = require('express');
const cors = require('cors');
const luxon = require('luxon');

const app = express();
const port = 9000;
const workJson = require('../Data/work.json');
const now = '2015-03-24 11:30:00 UTC';

app.use(cors());

app.get('/bobRoss', (req, res) => {
  res.send('The beautiful Bob Ross comin\' your way');
});

app.listen(port, () => {
  console.log(`We have lift off!
Snappet "server" listening on http://localhost:${port}`);
});
