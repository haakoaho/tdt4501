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
using tdt4501.Modules;
using FreshMvvm;

namespace tdt4501
{
    class MainPageModel : FreshBasePageModel
    {
        public string Longitude { set; get; }
        public string Latitude { set; get; }

        public MainPageModel(LocationModule locationModule)
        {
            Location location = Task.Run(async () => await locationModule.GetLocation()).Result;
            Longitude = "Longitude: " + location.Longitude.ToString();
            Latitude = "Latitude: " + location.Latitude.ToString();


        }


    }
}
