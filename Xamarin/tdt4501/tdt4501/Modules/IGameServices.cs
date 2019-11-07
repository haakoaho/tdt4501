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
        //start the Google Play Client
        void Start();
        //unlock the Achievement for the player
        void UnlockAchievement(String Achievement);

    }
}
