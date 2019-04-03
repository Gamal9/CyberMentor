using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMentor.View.MainMdPage
{

    public class MenuPageMenuItem
    {
        public MenuPageMenuItem()
        {
            Resource.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            NextPage = typeof(MenuPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Type NextPage { get; set; }

        //public ObservableCollection<MenuPageMenuItem> MenuItems()
        //{
        //    ObservableCollection<MenuPageMenuItem> items = new ObservableCollection<MenuPageMenuItem>
        //    {
        //        new MenuPageMenuItem
        //        {
        //            Title= Resource.MainPage , Url="home.png" , NextPage=typeof(WaselMainPage.MainPage)
        //        },
        //        new MenuPageMenuItem
        //        {
        //            Title=Resource.MasterAddAdv, Url="add.png" ,  NextPage=typeof(AddAdvertise)
        //        },
        //        new MenuPageMenuItem
        //        {
        //            Title=Resource.Orders , Url="orders.png" , NextPage=typeof(MyOrdersPage)
        //        },
        //        new MenuPageMenuItem
        //        {
        //            Title=Resource.MasterNotification , Url="notifion.png" , NextPage=typeof(NotificationPage)
        //        },
        //        new MenuPageMenuItem
        //        {
        //            Title=Resource.MasterSettings , Url="see.png", NextPage=typeof(SettingsPage)
        //        },
        //        new MenuPageMenuItem
        //        {
        //            Title=Resource.MasterAppLyc , Url="bi.png", NextPage=typeof(Policies)
        //        }

        //    };
        //    return items;
        //}

    }
}