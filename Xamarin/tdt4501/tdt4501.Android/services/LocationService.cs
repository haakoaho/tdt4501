using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using tdt4501.ExternalServices;
namespace tdt4501.Droid.services
{
    class LocationService : ILocationServices
    {
        public Tuple<int, int> GetGeoCoordinates()
        {
            return Tuple.Create(0, 0);
        }
    }
}