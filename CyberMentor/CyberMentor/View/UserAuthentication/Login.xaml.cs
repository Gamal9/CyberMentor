using CyberMentor.Helper;
using CyberMentor.Service;
using CyberMentor.View.MainMdPage;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;    
using Xamarin.Forms.Xaml;

namespace CyberMentor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            FlowDirection = (CyberMentor.Helper.AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            EntryEmail.Completed += (Object sender, EventArgs e) =>
            {
                EntryPassword.Focus();
            };
            EntryPassword.Completed += (Object sender, EventArgs e) =>
            {
                Loginbtn.Focus();
            };
        }

        private bool AllFieldsFilled()
        {
            bool check = ((String.IsNullOrEmpty(EntryEmail.Text)) || (String.IsNullOrEmpty(EntryPassword.Text))) ? false : true;
            if (EntryEmail.Text == null || EntryEmail.Text == null || EntryPassword.Text == null)
            {
                Activ.IsRunning = false;
                DisplayAlert("خطأ", "من فضلك أكمل الحقول الفارغة", "OK");
            }
            else if (EntryEmail.Text.Length < 1 || EntryEmail.Text.Length < 1 || EntryPassword.Text.Length < 1)
            {
                Activ.IsRunning = false;
                DisplayAlert("خطأ", "من فضلك أكمل الحقول الفارغة", "OK");
            }
            return check;

        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            RegLbl.IsEnabled = false;
            Navigation.PushModalAsync(new Register());
            RegLbl.IsEnabled = true;
        }
        bool checker = false;
        private async void Loginbtn_Clicked(object sender, EventArgs e)
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                if (AllFieldsFilled())
                {
                    Activ.IsRunning = true;
                    UserServices ser = new UserServices();
                    var user = await ser.UserLogin(EntryEmail.Text, EntryPassword.Text);
                    if (user == null)
                    {
                        Activ.IsRunning = false;
                        await DisplayAlert("Error", "من فضلك تحقق من كلمة المرور", "OK");
                        return;
                    }
                    else
                    {
                        checker = true;
                        AppSettings.LastUsedID = user.id;
                        AppSettings.LastUsedEmail = user.email;
                        AppSettings.UserHash = user.name;
                        PopAlert(checker);
                        Activ.IsRunning = false;
                        Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new MenuPage());
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "من فضلك تحقق من الإتصال بالإنترنت", "OK");
            }
        }

        private void PopAlert(bool x)
        {
            PopupNavigation.Instance.PushAsync(new RequestPopUp(x, 0));
            return;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Register());
        }
    }
}