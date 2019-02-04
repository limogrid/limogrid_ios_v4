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
	public partial class JobOfferPage : ContentPage
	{
        static WebView wv = new WebView();
		public JobOfferPage ()
		{

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            wv = Browser;
        }
        public static void carregarPg()
        {
            Debug.WriteLine("http://limogrid.com/api/limogrid/Views/JobOffer/pg_JobOffer.cfm?id_reserva=" + Data.Reservation.reservation.Id_reservation.ToString() + "&id_motorista=" + Data.User.driver.Id_Chauffeur.ToString());
            wv.Source = "http://limogrid.com/api/limogrid/Views/JobOffer/pg_JobOffer.cfm?id_reserva=" + Data.Reservation.reservation.Id_reservation.ToString() + "&id_motorista=" + Data.User.driver.Id_Chauffeur.ToString();

        }
        public static async Task fecharPgAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.RemovePage(page);
        }
    }
}