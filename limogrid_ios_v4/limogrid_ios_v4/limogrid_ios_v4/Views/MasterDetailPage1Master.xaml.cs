using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace limo_droid_v4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
            lblNomeUser.Text = Data.User.driver.First_Name + Data.User.driver.Last_Name;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }
            
            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
                    new MasterDetailPage1MenuItem { Id = 0, Title = "Driver Training Video" , Icon = "icon_yt.png"},
                    new MasterDetailPage1MenuItem { Id = 1, Title = "Profile"               , Icon = "icon_pf.png"},
                    new MasterDetailPage1MenuItem { Id = 2, Title = "Message Dispatch"      , Icon = "icon_md.png"},
                    new MasterDetailPage1MenuItem { Id = 3, Title = "Set Availability"      , Icon = "icon_sa.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Select Map Provider"   , Icon = "icon_mp.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Turn ON Vacation Mode" , Icon = "icon_vm.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Support & Feedback"    , Icon = "icon_sf.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Earnings"              , Icon = "icon_ea.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Ratings"               , Icon = "icon_rt.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Refer & Earn"          , Icon = "icon_re.png"},
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Sign Out"              , Icon = "icon_so.png"},
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}