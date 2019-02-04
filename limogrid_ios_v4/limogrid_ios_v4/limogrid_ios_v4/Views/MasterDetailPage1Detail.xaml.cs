using Plugin.Geolocator;
using Plugin.LocalNotifications;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MapKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoreLocation;

namespace limo_droid_v4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Detail : ContentPage
    {
        MKMapView maps = new MKMapView(UIKit.UIScreen.MainScreen.Bounds);
        
        string lat = "";
        string lon = "";
        Page pg_offer = new JobOfferPage();
       // Page pg_info = new JobInfoPage();
        Page pg_assig = new JobAssignedPage(); 
        static Grid pnljobs = new Grid();
        public MasterDetailPage1Detail()
        {
            InitializeComponent();
            pnljobs = pnlJob;
            new System.Threading.Thread(new System.Threading.ThreadStart(async () => {
                int t = 0;
                int flg_acao = 0; 
                while (true)
                {
                    try
                    {
                        var locator = CrossGeolocator.Current;
                        locator.DesiredAccuracy = 50;

                        var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                        lon = position.Longitude.ToString();
                        lat = position.Latitude.ToString();

                        int status = Data.Map.UpdateLocation(lat, lon, "1");
                        if (status == 0)
                        {
                            pnljobs.BackgroundColor = Color.FromHex("#2495c2");
                        }
                        else if(status  == 1)
                        {
                            pnljobs.BackgroundColor = Color.FromHex("#2495c2");
                        }
                        else if(status == -1 && flg_acao == 0)
                        {
                            //Navigation.PushAsync(this);
                            flg_acao = 1;
                        }
                        else if (status == -2 && flg_acao == 0)
                        {
                            //await JobOfferPage.fecharPgAsync(pg_offer);
                            //await Navigation.PushAsync(pg_info);
                            flg_acao = 1;
                        }
                        else if (status == -51)
                        {
                            string data = Data.Map.cache_action;
                            string reservation = data.Split('@')[0];
                            string chauffeur = data.Split('@')[1];
                            string op = data.Split('@')[2];
                            string param = data.Split('@')[3];
                            var uri = new Uri("waze://?ll="+param+"&navigate=yes");
                            Device.OpenUri(uri);
                        }
                        else
                        {
                            if (t > 2)
                            {

                                GerarNotificacao("NEW JOB", "[#" + status + "]");
                                //lblJobOffer.Text = "1 Jobs Offered";
                                Data.Reservation.SalvaId(status);
                                pnljobs.BackgroundColor = Color.FromHex("#2495c2");
                                //DisplayAlert("NEW JOB", "[#" + status + "]","Ok");
                                flg_acao = 0;
                            }
                        }
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        pnljobs.BackgroundColor = Color.FromHex("#2495c2");
                    }
                    t++;
                }
                
            })).Start();
            /*var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;*/
            GetPosition();

            var JobOffer_tap = new TapGestureRecognizer();
            JobOffer_tap.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(pg_offer);
                JobOfferPage.carregarPg();
            };
            lblJobOffer.GestureRecognizers.Add(JobOffer_tap);
            var JobAssigned_tap = new TapGestureRecognizer();
            JobAssigned_tap.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(pg_assig);
                JobAssignedPage.carregarPg();
            };
            lblJobAssigned.GestureRecognizers.Add(JobAssigned_tap);
        }
        private async void GetPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                lon = position.Longitude.ToString();
                lat = position.Latitude.ToString();
                Debug.WriteLine(lon);
                Debug.WriteLine(lat);
                CLLocationManager locationManager = new CLLocationManager();
                locationManager.RequestWhenInUseAuthorization();
                maps.AddAnnotations(new MKPointAnnotation()
                {
                    Title = "MyAnnotation",
                    Coordinate = new CLLocationCoordinate2D(Convert.ToDouble(lon), Convert.ToDouble(lat))
                });
               /* map.MoveToRegion(
                MapSpan.FromCenterAndRadius(
            new Position(Convert.ToDouble(lat), Convert.ToDouble(lon)), Distance.FromMiles(0.2)));
                map.UiSettings.ZoomControlsEnabled = false;
                var pos = new Position(Convert.ToDouble(lat), Convert.ToDouble(lon));
                var pin = new Pin
                {
                    Type = PinType.SearchResult,
                    Icon = BitmapDescriptorFactory.FromBundle("icon_car.png"),
                    Position = pos,
                    Label = "Atual Local",
                    Address = "custom detail info"
                };
                map.Pins.Add(pin);*/
            }
            catch(Exception ex)
            {
                GetPosition();
                Thread.Sleep(2000);
            }
        }

        private void GerarNotificacao(string titulo, string mensagem)
        {
            CrossLocalNotifications.Current.Show(titulo, mensagem);
            var v = CrossVibrate.Current;
            v.Vibration(TimeSpan.FromSeconds(1));
        }
    }
}