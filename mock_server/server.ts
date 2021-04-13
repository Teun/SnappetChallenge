const jsonServer = require('json-server');
const server = jsonServer.create();
const router = jsonServer.router('mock_server/db.json');
const middlewares = jsonServer.defaults();
const db = require('./db.json');
const fs = require('fs');

server.use(middlewares);
server.use(jsonServer.bodyParser);

server.get('/suggestions', (req: any, res: any) => {
  const students = returnSuggestions(req.query.filter);
  if (true) {
    res.send(students);
  } else {
    res.status(500).send('Internal Server Error');
  }
});


server.get('/rawData', (req: any, res: any) => {
  const rawData = returnRawData();
  if (true) {
    res.send(rawData);
  } else {
    res.status(500).send('Internal Server Error');
  }
});


server.use(router);
server.listen(3000, () => {
  console.log('JSON Server is running');
});



function returnSuggestions(searchTerm): any {
  const dbRaw = fs.readFileSync('./mock_server/data/suggestions.json');
  const students: [] = JSON.parse(dbRaw);
  if (searchTerm === ''){
    return [];
  }
  const result = students.filter((v: any) => v.term.toLowerCase().indexOf(searchTerm.toLowerCase()) > -1);
  return result;
}


function returnRawData(): any {
  const dbRaw = fs.readFileSync('./mock_server/data/rawdataset.json');
  const rawData = JSON.parse(dbRaw);
  return rawData;
}
