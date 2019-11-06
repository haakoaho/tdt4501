using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace tdt4501.ExternalServices
{
    //for injecting
    //ILocationServices locationServices = DependencyService.Get<ILocationServices>();
    //this is a tutorial for using Native service can be deleted
    public interface ILocationServices
    {
        Tuple<int,int> GetGeoCoordinates();
    }
}
