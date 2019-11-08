using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tdt4501.Modules;

namespace tdt4501.Models
{
    public class ChatRoom
    {


        public ChatRoom(string roomName)
        {
             initializeChatRoom(roomName);
        }

        private async Task initializeChatRoom(string roomName)
        {
           await CommunicationModule.Instance.Connect();
           await CommunicationModule.Instance.CreateRoom(roomName);
            CommunicationModule.Instance.Listen();
        }
        public async Task SendMessage(string message)
        {
            await CommunicationModule.Instance.SendMessage(message);

        }
    }

}
