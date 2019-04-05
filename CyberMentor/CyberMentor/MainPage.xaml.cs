using CyberMentor.Helper;
using CyberMentor.View;
using CyberMentor.View.MainMdPage;
using System;
using System.Collections.Generic;
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
            LblLanguage.Text = (AppSettings.LastUserGravity == "Arabic") ? "عربى" : "English";
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProtectMe());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CyberNews());
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CyberEvents());
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CyberTube());
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            AppSettings.LastUserGravity=(LblLanguage.Text=="عربي") ? "Arabic" :"English";
            App.Current.MainPage = new MenuPage();
        }
    }
}
