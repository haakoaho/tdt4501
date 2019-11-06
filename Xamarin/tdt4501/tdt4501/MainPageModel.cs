using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using tdt4501.ExternalServices;
using FreshMvvm;

namespace tdt4501
{
    class MainPageModel : FreshBasePageModel
    {
        public string Longitude { set; get; }
        public string Latitude { set; get; }
        Tuple<int, int> coordinatesTuple { get; set; } = Tuple.Create(4, 4);

        public MainPageModel()
        {
            ILocationServices locationServices = DependencyService.Get<ILocationServices>();
            Location location = Task.Run(async () => await GetLocation()).Result;
            Longitude = "Longitude: " + location.Longitude.ToString();
            Latitude = "Latitude: " + location.Latitude.ToString();


        }

        Task<Location> GetLocation()
        {
            return Geolocation.GetLastKnownLocationAsync();
        }
    }
}
