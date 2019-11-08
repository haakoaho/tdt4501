using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tdt4501.Modules;

namespace tdt4501.Models
{
    public class ChatRoom
    {
        Task InitTask;

        public ChatRoom()
        {
            InitTask = initializeChatRoom();
        }

        private async Task initializeChatRoom()
        {
           await CommunicationModule.Instance.Connect();
           await CommunicationModule.Instance.CreateRoom("testRoom");
        }
    }

}
