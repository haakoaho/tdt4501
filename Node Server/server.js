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


  // Creates a new room with regards to request
  socket.on('create room', function (data) {
    console.log('room created');
    console.log('room: ' + data);
    rooms.push(data);
    socket.join(data);
    myroom = data
    webSocket.sockets.in(data).emit('connectToRoom', 'Joined ' + data);
  });

  // join a room
  socket.on('join room', function (data) {
    console.log('room joined');
    var checkRoom = null;
    var checkRoom = _.find(rooms, {'name': data});

    if (myroom == data) {
      console.log('already in' + myroom);
    } else if (checkRoom != null) {
      socket.join(data);
      myroom = data;
      socket.emit('connectToRoom', 'Joined ' + myroom);
    }
  });


  function getRoom(){
      return rooms.find(myroom);
  }

  // When a player sends data
  socket.on('new message', function (message) {
    console.log(message);
    if (myroom == null) {
      return;
    }
  webSocket.sockets.in(myroom).emit('new message', JSON.stringify(message));
  });
});



http.listen(port, function () {
  console.log('Listening on ' + port);
});