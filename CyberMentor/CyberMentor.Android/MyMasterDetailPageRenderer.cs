﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using CyberMentor.Droid;
using CyberMentor.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(MyMasterDetailPageRenderer))]
namespace CyberMentor.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class MyMasterDetailPageRenderer : MasterDetailPageRenderer
    {
        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            var fieldInfo = GetType().BaseType.GetField("_masterLayout", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var _masterLayout = (ViewGroup)fieldInfo.GetValue(this);
            var lp = new DrawerLayout.LayoutParams(_masterLayout.LayoutParameters);
            lp.Gravity = GravityClass.Grav();
            _masterLayout.LayoutParameters = lp;
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}