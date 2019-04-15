using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using Plugin.Connectivity;
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
	public partial class AddReviewPage : ContentPage
	{
        int ID;
		public AddReviewPage (int id)
		{
			InitializeComponent ();
            ID = id;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                CyberReview review = new CyberReview
                {
                    title = EntryTitle.Text,
                    desc = EntryDesc.Text,
                    user_id = AppSettings.LastUsedID,
                    post_id = ID
                };
                TubeServices ser = new TubeServices();
                var response = await ser.PostReview(review);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error",Resource.ErrorMessage,"ok");
            }
        }
    }
}