using CyberMentor.Helper;
using CyberMentor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor.View.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TubeLink : ContentPage
	{
		public TubeLink (YoutubeItem item, string src)
		{
			InitializeComponent ();
            FlowDirection = (AppSettings.LastUserGravity == "English") ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
            BackImg.Rotation = (AppSettings.LastUserGravity == "English") ? 180 : 0;
            WebKey.Source = src;
            this.BindingContext = item;
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        
    }
}