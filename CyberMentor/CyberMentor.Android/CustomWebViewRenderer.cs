using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CyberMentor.Model;
using Xamarin.Forms.Platform.Android;

namespace CyberMentor.Droid
{
    public class CustomWebViewRenderer : WebViewRenderer, ICustomWebViewRenderer
    {
        Android.Webkit.WebView webView;

        public CustomWebViewRenderer(Android.Content.Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            webView = Control;
            if (e.OldElement != null)
                (e.OldElement as CustomWebView).renderer = null;
            if (e.NewElement != null)
                (e.NewElement as CustomWebView).renderer = this;
        }

        public void Pause()
        {
            if (webView != null) webView.OnPause();
        }

        public void Resume()
        {
            if (webView != null) webView.OnResume();
        }
    }
}