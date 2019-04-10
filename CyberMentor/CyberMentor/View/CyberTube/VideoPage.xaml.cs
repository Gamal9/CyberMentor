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
	public partial class VideoPage : ContentPage
	{
		public VideoPage (string src)
		{
			InitializeComponent ();
            webView.Source = "https://www.youtube.com/embed/" + src;
        }
	}
}