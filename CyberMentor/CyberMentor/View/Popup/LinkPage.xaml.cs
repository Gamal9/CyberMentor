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
            FlowDirection = (AppSettings.LastUserGravity == "English") ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 180 : 0;
            LblLink.Text = src;
            webView.Source = src;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}