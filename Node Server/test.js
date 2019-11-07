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



describe('messages', function () {
  it('should receive sent  message', function (done) {
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
          expect(text).to.equal('abcd');
        }
      },
      emit: {
        'join room': 'velociraptor1',
        'new message': 'abcd'
      }
    };

    socketTester.run([client1, client2], done);
  });

  it("client from different room doesn't recieve the message", function (done) {
    var client1 = {
      on: {
        'new message': socketTester.shouldNotBeCalled()
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
        'new message': '(123,456)'
      }
    };
    socketTester.run([client1, client2, client3], done);
  });
});
