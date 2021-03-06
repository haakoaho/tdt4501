﻿using System;
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
using tdt4501.Models;


namespace tdt4501
{
    class MainPageModel : FreshBasePageModel
    {
        public string Longitude { set; get; }
        public string Latitude { set; get; }

        public MainPageModel()
        {
            Location location = Task.Run(async () => await LocationModule.Instance.GetLocation()).Result;
            Longitude = "Longitude: " + location.Longitude.ToString();
            Latitude = "Latitude: " + location.Latitude.ToString();
        }
        public Command ButtonPressed
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage = FreshPageModelResolver.ResolvePageModel<GameSceneAPageModel>();
                });
            }
        }

    }
}
