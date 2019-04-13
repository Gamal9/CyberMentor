using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using CyberMentor.View.Popup;
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
	public partial class ProtectMe : ContentPage
	{
        int ID;
		public ProtectMe (int id)
		{
			InitializeComponent ();
            StkMain.IsVisible = true;
            StkError.IsVisible = false;
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 0 : 180;
            ID = id;
            DataGetter();
		}

        private async void DataGetter()
        {
            Activ.IsRunning = true;
            if(CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                var items = await ser.AllSubItemsPage(ID);
                if (items.Count == 0)
                {
                    StkMain.IsVisible = false;
                    StkError.IsVisible = true;
                    LblError.Text = Resource.NoBuildings;
                }
                else
                {
                    list.FlowItemsSource = items;
                }
            }
            else
            {
                StkMain.IsVisible = false;
                StkError.IsVisible = true;
                LblError.Text = Resource.ErrorMessage;
            }
            Activ.IsRunning = false;
        }

        private void List_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CyberNewsModel;
            Navigation.PushAsync(new LinkPage(item.link));
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
            DataGetter();
        }
    }
}