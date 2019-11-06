using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tdt4501.Models;

namespace tdt4501.ExternalServices
{
    //for injecting
    //ILocationServices locationServices = DependencyService.Get<ILocationServices>();
    //this is a tutorial for using Native service can be deleted
    public interface IGameServices
    {
        void EnterMultiPlayerLobby();
        void UnlockAchievement(String Achievement);
        void SendData(Byte data);
        Byte ReceiveData();
    }
}
