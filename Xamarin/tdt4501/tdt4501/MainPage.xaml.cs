using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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
            coordinatesTuple= locationServices.GetGeoCoordinates();
            InitializeComponent();
        }
    }
}
