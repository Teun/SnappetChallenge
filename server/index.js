const express = require('express');
const cors = require('cors');
const app = express();

app.use(cors());

const http = require('http');
const server = http.createServer(app);
const io = require('socket.io')(server, {
    cors: {
        origin: 'http://localhost:4200',
        methods: ['GET'],
    }
});
const data = require('./work.json');
const users = require('./users.json');

let set = new Set();
data.forEach(x => set.add(x.UserId));

const sendAnswers = (index, delay) => {
    const answer = data[index];

    if (answer == null) {
        return;
    }

    io.send(answer);

    setTimeout(() => {
        sendAnswers(index + 1);
    }, 5000);
};

io.on('connection', (socket) => {
    sendAnswers(0);
});

app.get('/users', (req, res) => {
    res.send(users);
});

server.listen(8988);
