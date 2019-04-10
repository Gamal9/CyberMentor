using CyberMentor.Helper;
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
	public partial class LogoutPopup : PopupPage
    {
		public LogoutPopup ()
		{
			InitializeComponent ();
            FlowDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AppSettings.LastUsedID = 0;
            App.Current.MainPage = new Login();
            PopupNavigation.Instance.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}