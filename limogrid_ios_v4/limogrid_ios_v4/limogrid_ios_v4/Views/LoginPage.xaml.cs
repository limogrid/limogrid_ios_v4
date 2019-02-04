using limo_droid_v4.Models;
using Plugin.DeviceInfo;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
	public partial class LoginPage : ContentPage
	{
       
        string deviceId = "";
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            VerficarLocalizacao();
            deviceId = CrossDevice.Device.DeviceId;
            if (Data.User.VerificarLoginAnterior(deviceId))
            {
                Navigation.PushAsync(new MasterDetailPage1());
            }

        }
        async void VerficarLocalizacao()
        {

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "LimoGrid need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        async void SignInProcedure(object sender, EventArgs e)
        {
            User user;
            try
            {
                user = new User(txt_user.Text.ToString(), txt_pass.Text.ToString(), deviceId, txt_company.Text.ToString());
            }
            catch (Exception)
            {
                user = new User("", "", "", "");
            }

            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success !", "Ok");
                await Navigation.PushAsync(new MasterDetailPage1());
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty Username/Password !", "Ok");
            }

        }
    }
}