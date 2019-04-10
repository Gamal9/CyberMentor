using CyberMentor.Service;
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
	public partial class SubItemsPage : ContentPage
	{
        int id;
		public SubItemsPage (int _id)
		{
			InitializeComponent ();
            id = _id;
		}

        private async void DataGetter()
        {
            TubeServices ser = new TubeServices();
            var data = await ser.AllSubItemsPage();
            list.ItemsSource = data;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void List_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}