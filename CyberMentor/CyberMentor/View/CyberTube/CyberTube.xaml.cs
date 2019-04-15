using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.View.Popup;
using CyberMentor.ViewModel;
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
	public partial class CyberTube : ContentPage
	{
		public CyberTube ()
		{
			InitializeComponent ();
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 180 : 0;
        }

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CyberMentor.Model.CyberModel;
            string src = "https://www.youtube.com/watch?v=" + item.key;
            Navigation.PushAsync(new LinkPage(src));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = null;
            TubeViewModel vm = new TubeViewModel();
            this.BindingContext = vm;
        }

        //protected override void OnDisappearing()
        //{
        //    webView.Pause();
        //    base.OnDisappearing();
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    webView.Resume();
        //}
    }
}