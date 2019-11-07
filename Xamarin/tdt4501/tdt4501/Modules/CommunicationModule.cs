using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace tdt4501.Modules
{
    public sealed class CommunicationModule
    {
        private static CommunicationModule instance = null;
        private static readonly object padlock = new object();

        public static readonly string ServerAdress = "http://192.168.0.3";
        public static readonly int port = 3001;
        public static readonly Uri server = new Uri("http://192.168.0.3:3001");
        SocketIOClient.SocketIO client = new SocketIOClient.SocketIO(server);
        CommunicationModule() {}

        public static CommunicationModule Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CommunicationModule();
                    }
                    return instance;
                }
            }
        }
        public async Task Connect()
        {
            client.ConnectAsync();
        }
        public async Task JoinRoom(String room)
        {
            //Client.Send(")
        }
        public async Task CreateRoom(String room)
        {
             //Socket.EmitAsync("create room", room);
        }
    }
}
