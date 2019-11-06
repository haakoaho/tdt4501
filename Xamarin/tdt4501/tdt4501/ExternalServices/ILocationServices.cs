using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace tdt4501.ExternalServices
{
    interface ILocationServices
    {
        Task<Tuple<int,int>> GetGeoCoordinatesAsync();
    }
}
