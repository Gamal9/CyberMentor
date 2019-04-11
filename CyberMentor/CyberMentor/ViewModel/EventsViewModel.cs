using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CyberMentor.ViewModel
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        public EventsViewModel()
        {
            IsRunning = true;
            MainVisable = true;
            VisableError = false;
            PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            DataGetter();
            IsRunning = false;
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged(); }
        }

        private FlowDirection _pageDirection;

        public FlowDirection PageDirection
        {
            get { return _pageDirection; }
            set { _pageDirection = value; }
        }

        private ObservableCollection<CyberNewsModel> _events;

        public ObservableCollection<CyberNewsModel> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged(); }
        }

        private string _ErrorValue;
        public string ErrorValue
        {
            get { return _ErrorValue; }
            set { _ErrorValue = value; OnPropertyChanged(); }
        }

        public bool VisableError { get; set; }
        public bool MainVisable { get; set; }


        private async void DataGetter()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                Events = await ser.GetAllEvents();
                if(Events.Count==0)
                {
                    MainVisable = false;
                    VisableError = true;
                    ErrorValue = Resource.NoBuildings;
                }
            }
            else
            {
                MainVisable = false;
                VisableError = true;
                ErrorValue = Resource.ErrorMessage;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
