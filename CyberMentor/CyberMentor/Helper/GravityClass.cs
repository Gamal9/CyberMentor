using Android.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Helper
{
    public class GravityClass
    {
        public static int Grav()
        {
            if (AppSettings.LastUserGravity == "Arabic")
            {
                return (int)GravityFlags.Right;
            }
            else
            {
                return (int)GravityFlags.Left;
            }
        }
    }

}
