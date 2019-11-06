using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace tdt4501.ExternalServices
{
    public interface ILocationServices
    {
        Tuple<int,int> GetGeoCoordinates();
    }
}
