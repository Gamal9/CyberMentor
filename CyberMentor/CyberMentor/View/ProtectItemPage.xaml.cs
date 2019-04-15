using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using CyberMentor.View.Popup;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProtectItemPage : ContentPage
	{
        CyberNewsModel item;
        ObservableCollection<CyberReview> Reviews;
        public ProtectItemPage (CyberNewsModel _item)
		{
			InitializeComponent ();
            Title = _item.title;
            FlowDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            item = _item;
            LblTitle.Text = item.title;
            LblBody.Text = item.body;
            DataGetter();
		}

        private async void DataGetter()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                Reviews = await ser.NewsReview(item.id);
                list.ItemsSource = Reviews;
            }
            else
            {

            }
        }

       

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddReviewPage(item.id));
        }
    }
}