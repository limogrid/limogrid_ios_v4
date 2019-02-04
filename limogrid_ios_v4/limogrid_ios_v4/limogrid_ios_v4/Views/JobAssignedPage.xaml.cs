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
	public partial class JobAssignedPage : ContentPage
	{
        static WebView wv = new WebView();
        public JobAssignedPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            wv = Browser;
		}
        public static void carregarPg()
        {
            Debug.WriteLine("http://limogrid.com/api/limogrid/Views/JobAssigned/pg_JobAssigned.cfm?id_motorista="+ Data.User.driver.Id_Chauffeur.ToString());
            wv.Source = "http://limogrid.com/api/limogrid/Views/JobAssigned/pg_JobAssigned.cfm?id_motorista=" + Data.User.driver.Id_Chauffeur.ToString();

        }
    }
}