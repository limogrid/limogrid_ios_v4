using limo_droid_v4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace limo_droid_v4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
            Driver driver = Data.User.driver;
            Browser.Source = "http://limogrid.com/api/limogrid/views/profile/pg_profile.cfm?id_driver=" + driver.Id;
        }
	}
}