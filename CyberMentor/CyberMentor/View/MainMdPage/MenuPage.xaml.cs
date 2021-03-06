﻿using CyberMentor.Helper;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CyberMentor.View.MainMdPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
            //BindingContext = new MenuPageMasterViewModel();
            FlowDirection = (CyberMentor.Helper.AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.NextPage);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}