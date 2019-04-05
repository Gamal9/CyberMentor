using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CyberMentor.Model
{
    public class CustomWebView : WebView
    {
        public ICustomWebViewRenderer renderer;

        public void Pause()
        {
            if (renderer != null) renderer.Pause();
        }

        public void Resume()
        {
            if (renderer != null) renderer.Resume();
        }
    }
}
