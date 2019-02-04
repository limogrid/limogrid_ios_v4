using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace limo_droid_v4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
            if(item.Title == "Driver Training Video")
            {
                Device.OpenUri(new Uri("vnd.youtube://watch?v=2kFYW9sst6M"));
            }
            if (item.Title == "Profile")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new ProfilePage());
            }
            if (item.Title == "Message Dispatch")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new MessagePage());
            }
            if (item.Title == "Set Availability")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new SetAvailabilityPage());
            }
            if (item.Title == "Select Map Provider")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new MapProviderPage());
            }
            if (item.Title == "Turn ON Vacation Mode")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new VacationMode());
            }
            if (item.Title == "Support & Feedback")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new SupportPage());
            }
            if (item.Title == "Earnings")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new EarningsPage());
            }
            if (item.Title == "Ratings")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new RatingsPage());
            }
            if (item.Title == "Earnings")
            {
                Debug.Write("-----------------------");
                Navigation.PushAsync(new EarningsPage());
            }
            if (item.Title == "Refer & Earn")
            {
                /*Debug.Write("-----------------------");
                Navigation.PushAsync(new ReferPage());*/

                var uri = new Uri("http://maps.google.com/maps?saddr=Google+Inc,+8th+Avenue,+New+York,+NY&daddr=John+F.+Kennedy+International+Airport,+Van+Wyck+Expressway,+Jamaica,+New+York&directionsmode=transit");
                //var uri = new Uri("waze://?ll=-23.5113691, -46.87294199999999&navigate=yes");
                Device.OpenUri(uri);
            }
            if(item.Title == "Sign Out")
            {
                //var uri = new Uri("http://maps.google.com/maps?saddr=Google+Inc,+8th+Avenue,+New+York,+NY&daddr=John+F.+Kennedy+International+Airport,+Van+Wyck+Expressway,+Jamaica,+New+York&directionsmode=transit");
                var uri = new Uri("waze://?ll=-23.5113691, -46.87294199999999&navigate=yes");
                Device.OpenUri(uri);
            }

            Debug.WriteLine(item.Title);
        }
    }
}