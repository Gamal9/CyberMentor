using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.View.Popup;
using Rg.Plugins.Popup.Services;
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

namespace CyberMentor.View.MainMdPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView;

        int rout = 180;
        public MenuPageMaster()
        {
            InitializeComponent();
            LblName.Text = AppSettings.UserHash;
            LblEmail.Text = AppSettings.LastUsedEmail;
            //ListView = MenuItemsListView;
        }

        class MenuPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuPageMenuItem> MenuItems { get; set; }
            
            public MenuPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuPageMenuItem>(new[]
                {
                    new MenuPageMenuItem { Id = 0, Title = "Page 1" },
                    new MenuPageMenuItem { Id = 1, Title = "Page 2" },
                    new MenuPageMenuItem { Id = 2, Title = "Page 3" },
                    new MenuPageMenuItem { Id = 3, Title = "Page 4" },
                    new MenuPageMenuItem { Id = 4, Title = "Page 5" },
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LogoutPopup());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            rout = (rout > 360) ? rout - 360 : rout;
            rout += 180;
            await ArrowImg.RotateTo(rout,500,Easing.SpringIn);
            StkItems.IsVisible = !StkItems.IsVisible;
        }

        private void StkItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as CatModel;
            switch (item.id)
            {
                case 4:
                    (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new CyberTube());
                    break;
                case 3:
                    (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new CyberEvents());
                    break;
                case 2:
                    (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new CyberMentor.View.CyberNews());
                    break;
                case 1:
                    (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SubCategories(item.sub_categories));
                    break;
            }
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
            App.Current.MainPage = new MenuPage();
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new AboutPage());
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;

        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PolicyPage());
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}