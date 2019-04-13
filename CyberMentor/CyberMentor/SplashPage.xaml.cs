using CyberMentor.Helper;
using CyberMentor.View;
using CyberMentor.View.MainMdPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashPage : ContentPage
	{
		public SplashPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetMainPage();
        }

        private void SetMainPage()
        {
            if (AppSettings.LastUsedID == 0)
            {
                App.Current.MainPage = new Login();
            }
            else if (AppSettings.LastUsedID != 0)
            {
                App.Current.MainPage = new MenuPage();                
            }
        }
    }
}