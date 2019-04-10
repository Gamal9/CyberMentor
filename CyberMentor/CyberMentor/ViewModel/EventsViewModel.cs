using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
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

        private async void DataGetter()
        {
            TubeServices ser = new TubeServices();
            Events = await ser.GetAllEvents();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
