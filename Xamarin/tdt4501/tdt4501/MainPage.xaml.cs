using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using tdt4501.ExternalServices;


namespace tdt4501
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Tuple<int, int> coordinatesTuple { get; set; } = Tuple.Create(4,4);
        String text1{ get { return "hello world"; } }
        public MainPage()
        {
            ILocationServices locationServices = DependencyService.Get<ILocationServices>();
            Location location = Task.Run(async () => await GetLocation()).Result;
            InitializeComponent();
        }
        Task<Location> GetLocation()
        {
            return Geolocation.GetLastKnownLocationAsync();
        }
    }
}
