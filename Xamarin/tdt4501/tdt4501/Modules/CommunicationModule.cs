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
           await client.ConnectAsync();
           await Task.Delay(1000);
        }
        public async Task JoinRoom(String room)
        {
            await client.EmitAsync("join room", room);
        }
        public async Task CreateRoom(String room)
        { 
            await client.EmitAsync("create room", room);
        }
    }
}
