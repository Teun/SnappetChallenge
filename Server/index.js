const express = require('express');
const app = express();
const port = 9000;

app.get('/', (req, res) => {
  res.send('The beautiful Bob Ross comin\' your way');
});

app.listen(port, () => {
  console.log(`We have lift off!
Snappet "server" listening on http://localhost:${port}`);
});
