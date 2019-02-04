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
    public partial class SplasPage : ContentPage
    {
        Image splashImage;

        public SplasPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "icon_car.png",
                WidthRequest = 200,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#124a61");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(2, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}