using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.View;
using CyberMentor.View.MainMdPage;
using CyberMentor.ViewModel;
using Newtonsoft.Json.Linq;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CyberMentor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlowDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            LblLanguage.Text = (AppSettings.LastUserGravity == "Arabic") ? "English" : "عربى";
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(AppSettings.LastUserGravity));
            Resource.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }


        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            AppSettings.LastUserGravity=(LblLanguage.Text=="عربى") ? "Arabic" :"English";
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(AppSettings.LastUserGravity));
            Resource.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            App.Current.MainPage = new MenuPage();
            LblLanguage.Text = (LblLanguage.Text == "عربى") ? "English" : "عربى";
        }


        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CatModel;
            var title = (AppSettings.LastUserGravity == "Arabic") ? item.ar_name : item.en_name;
            switch (item.id)
            {
                case 4:
                    Navigation.PushAsync(new CyberTube(title));
                    break;
                case 3:
                    Navigation.PushAsync(new CyberEvents(title));
                    break;
                case 2:
                    Navigation.PushAsync(new CyberMentor.View.CyberNews(title));
                    break;
                case 1:
                    Navigation.PushAsync(new SubCategories(item.sub_categories));
                    break;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MenuPage();
        }
    }
}
