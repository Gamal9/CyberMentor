using CyberMentor.Service;
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
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private bool AllFieldsFilled()
        {
            bool check = ((String.IsNullOrEmpty(EntryEmail.Text)) || (String.IsNullOrEmpty(EntryPassword.Text))|| (String.IsNullOrEmpty(ConfirmPassword.Text))) ? false : true;
            if (ConfirmPassword.Text == null || EntryEmail.Text == null || EntryPassword.Text == null)
            {
                Activ.IsRunning = false;
                DisplayAlert("خطأ", "من فضلك أكمل الحقول الفارغة", "OK");
            }
            else if (ConfirmPassword.Text.Length < 1 || EntryEmail.Text.Length < 1 || EntryPassword.Text.Length < 1)
            {
                Activ.IsRunning = false;
                DisplayAlert("خطأ", "من فضلك أكمل الحقول الفارغة", "OK");
            }
            return check;

        }

        bool checker = false;
        private async void Regbtn_Clicked(object sender, EventArgs e)
        {
            Activ.IsRunning = true;
            if(CrossConnectivity.Current.IsConnected)
            {
                if (EntryPassword.Text != ConfirmPassword.Text)
                {
                    await DisplayAlert("Error", "كلمة المرور غير متطابقة", "OK");
                }
                else
                {
                    if (AllFieldsFilled())
                    {
                        UserServices ser = new UserServices();

                        var user = await ser.Register(EntryEmail.Text, EntryPassword.Text, EntryName.Text);
                        if (user == null)
                        {
                            await DisplayAlert("Error", "من فضلك تحقق من كلمة المرور", "OK");
                            return;
                        }
                        else
                        {
                            checker = true;
                            PopAlert(checker);
                            Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new Login());
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "من فضلك تحقق من الإتصال بالإنترنت", "OK");
            }
            Activ.IsRunning = false;
        }

        private void PopAlert(bool x)
        {
            PopupNavigation.Instance.PushAsync(new RequestPopUp(x, 1));
            return;
        }
    }
}