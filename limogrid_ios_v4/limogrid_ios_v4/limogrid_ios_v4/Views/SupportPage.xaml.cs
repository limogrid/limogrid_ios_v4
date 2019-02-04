using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace limo_droid_v4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public SupportPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Email Fleet",
                "Send Feedback",
                "Call Dispatch",
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", e.Item.ToString() , "OK");

            if (e.Item.ToString() == "Email Fleet")
            {
                Device.OpenUri(new Uri("mailto:limogrid.api@gmail.com"));
            }
            if (e.Item.ToString() == "Send Feedback")
            {

            }
            if (e.Item.ToString() == "Call Dispatch")
            {
                Device.OpenUri(new Uri("tel:+5511945692591"));
            }

          //Deselect Item
          ((ListView)sender).SelectedItem = null;
        }
    }
}
