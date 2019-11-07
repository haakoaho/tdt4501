var app = require('./index');
var socketUrl = 'http://localhost:3001';

var expect = require('chai').expect;
var request = require('request');

var users;


// sockettester
const io = require('socket.io-client');
const SocketTester = require('socket-tester');
const options = {
  transports: ['websocket'],
  'force new connection': true
};

var socketTester = new SocketTester(io, socketUrl, options);


describe('Rooms', function () {
  it('creates a new room', function (done) {
    var client1 = {
      on: {
        'created room': socketTester.shouldBeCalledNTimes(1)
      },
      emit: {
        'create room': 'velioroom'
      }
    };
    socketTester.run([client1], done);
  });

  it('Should join existing room', function (done) {
    var client1 = {
      on: {
        'connectToRoom': socketTester.shouldBeCalledNTimes(1)
      },
      emit: {'join room': 'velioroom'}
    };
    socketTester.run([client1], done);
  });

  it('Should not join non existing room', function (done) {
    var client1 = {
      on: {
        'connectToRoom': socketTester.shouldNotBeCalled()
      },
      emit: {'join room': 'non-existing room'}
    };
    socketTester.run([client1], done);
  });
});

describe('messages', function () {
  it('Sends a message to the room', function (done) {
    client1 = {
      on: {'new message': socketTester.shouldBeCalledNTimes(1)},
      emit: {
        'create room': 'velociraptor1'
      }
    };

    client2 = {
      on: {
        'new message': function (data) {
          var text = JSON.parse(data).text;
          expect(text).to.equal('(123,456)');
        }
      },
      emit: {
        'join room': 'tdt4143',
        'new message': '(123,456)'
      }
    };

    socketTester.run([client1, client2], done);
  });

  it("client from different room doesn't recieve the message", function (done) {
    var client1 = {
      on: {
        'new question': socketTester.shouldNotBeCalled()
      },
      emit: {
        'create room': 'T-rex'
      }
    };
    var client2 = {
      emit: {
        'create room': 'velociraptor2'
      }
    };
    var client3 = {
      emit: {
        'join room': 'velociraptor2',
        'new question': '(123,456)'
      }
    };
    socketTester.run([client1, client2, client3], done);
  });
});
