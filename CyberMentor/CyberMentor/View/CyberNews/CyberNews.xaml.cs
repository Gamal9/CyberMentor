using CyberMentor.Model;
using CyberMentor.View.Popup;
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
	public partial class CyberNews : ContentPage
	{
		public CyberNews ()
		{
			InitializeComponent ();
		}

        private void List_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CyberNewsModel;
            PopupNavigation.Instance.PushAsync(new LinkPage(item.link));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}