using System;
using System.Collections.Generic;
using System.Text;
using SocketIOClient;

namespace tdt4501.Modules
{
    public class CommunicationModule
    {
        public static readonly Uri server = new Uri("localhost:3001");
        SocketIO Socket = new SocketIO(server);
    }
}
