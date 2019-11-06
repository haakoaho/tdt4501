using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace tdt4501.Modules
{
    public sealed class LocationModule
    {
        private static LocationModule instance = null;
        private static readonly object padlock = new object();

        LocationModule(){
        }

        public static LocationModule Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LocationModule();
                    }
                    return instance;
                }
            }
        }


        public Task<Location> GetLocation()
        {
            return Geolocation.GetLastKnownLocationAsync();
        }
}
}
