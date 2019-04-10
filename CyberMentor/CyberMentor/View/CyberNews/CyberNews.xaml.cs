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

        }
    }
}