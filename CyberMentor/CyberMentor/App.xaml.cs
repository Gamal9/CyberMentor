using CyberMentor.Helper;
using CyberMentor.View;
using CyberMentor.View.MainMdPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CyberMentor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = (AppSettings.LastUsedID != 0)? new NavigationPage(new MenuPage()) : new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
