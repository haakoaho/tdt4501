const express = require('express');
const app = express();
const http = require('http').Server(app);
const webSocket = require('socket.io')(http);


var messages = [];
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
    var roomobj = {'name': data, 'messages': []};
    console.log('room: ' + roomobj.name);
    rooms.push(roomobj);
    socket.join(roomobj.name);
    myroom = roomobj.name;
    webSocket.sockets.in(roomobj.name).emit('connectToRoom', 'Joined ' + roomobj.name);
    socket.emit('created room', roomobj.room);
  });

  // join a room
  socket.on('join room', function (data) {
    var checkRoom = null;
    var checkRoom = _.find(rooms, {'name': data});

    if (myroom == data) {
      console.log('already in' + myroom);
    } else if (checkRoom != null) {
      socket.join(data);
      myroom = data;
      socket.emit('connectToRoom', 'Joined ' + myroom);
      socket.emit('all questions', JSON.stringify(checkRoom.questions));
    }
  });

  // Function to load every question to a given room
  function emitAllQuestions () {
        webSocket.sockets.in(myroom).emit('all questions', JSON.stringify(getRoom().questions));
    }

  function getRoom(){
      return rooms.find(myroom);
  }

  // When a player sends data
  socket.on('new message', function (message) {
    if (myroom == null) {
      return;
    }
    var message =
      {
        'text': message,
        'id': id,
      };

    for (var i = 0; i < rooms.length; i++) {
      if (rooms[i].name == myroom) {
        rooms[i].questions.push(question);
      }
    };
    console.log('newquestioninroom', myroom);
    webSocket.sockets.in(myroom).emit('new messages', JSON.stringify(question));
  });
});

// shutdown hook //
const shutdown = function () {
  console.log('Shutting down ...');
  db.close();
  process.exit();
};

process.on('SIGTERM', shutdown);
process.on('SIGINT', shutdown);
// shutdown hook //

// Deciding which port
http.listen(port, function () {
  console.log('Listening on ' + port);
});