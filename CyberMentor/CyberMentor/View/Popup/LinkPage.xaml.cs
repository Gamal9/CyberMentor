using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberMentor.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor.View.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LinkPage : ContentPage
	{
		public LinkPage (string src)
		{
			InitializeComponent ();
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 0 : 180;
            LblLink.Text = src;
            webView.Source = src;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}