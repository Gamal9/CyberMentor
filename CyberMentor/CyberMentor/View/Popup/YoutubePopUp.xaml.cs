using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor.View.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class YoutubePopUp : PopupPage
	{
		public YoutubePopUp (string src)
		{
			InitializeComponent ();
            webView.Source = "https://www.youtube.com/embed/" + src;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            webView.Resume();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}