﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using tdt4501.Modules;
using tdt4501;

namespace tdt4501
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        var page = FreshPageModelResolver.ResolvePageModel <MainPageModel>();  
        var basicNavContainer = new FreshNavigationContainer(page);  
        MainPage = basicNavContainer; 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
