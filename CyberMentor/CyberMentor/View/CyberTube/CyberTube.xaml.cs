using CyberMentor.Model;
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
		}

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CyberMentor.Model.CyberModel;
            Navigation.PushModalAsync(new VideoPage(item.key));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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