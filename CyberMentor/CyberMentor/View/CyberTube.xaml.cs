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

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as YoutubeItem;
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