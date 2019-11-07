const express = require('express');
const app = express();
const http = require('http').Server(app);
const webSocket = require('socket.io')(http);
const _ = require('lodash');


var rooms = [];
const port = 3001;

// initializing http
//app.use('/', express.static(path.join(__dirname, 'public')));



// When a client connects
webSocket.on('connection', function (socket) {
  var address = socket.handshake.address;
  var myroom = null;
  console.log('new connection');


  socket.on('create room', function (data) {
    rooms.push(data);
    socket.join(data);
    console.log("my data " + data);
    myroom = data
  });

  // join a room
  socket.on('join room', function (data) {
      socket.join(data);
      myroom = data;
    }
  );


  // When a player sends data
  socket.on('new message', function (data) {
    socket.to(myroom).emit('new message', JSON.stringify(data));
  });
});



http.listen(port, function () {
  console.log('Listening on ' + port);
});