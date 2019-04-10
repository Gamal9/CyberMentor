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
            list.FlowItemsSource = cats;
		}

        private void List_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}