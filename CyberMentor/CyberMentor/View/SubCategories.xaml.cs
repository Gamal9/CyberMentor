using CyberMentor.Helper;
using CyberMentor.Model;
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
	public partial class SubCategories : ContentPage
	{
		public SubCategories (List<SubCatModel> cats)
		{
			InitializeComponent ();
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 180 : 0;
            list.FlowItemsSource = cats;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        private void List_FlowItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SubCatModel;
            Navigation.PushAsync(new ProtectMe(item.id));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}