using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CyberMentor.ViewModel
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        public NewsViewModel()
        {
            IsRunning = true;
            PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            DataGetter();
            IsRunning = false;
        }

        private ObservableCollection<CyberNews> _news;
        public ObservableCollection<CyberNews> AllNews
        {
            get { return _news; }
            set { _news = value; OnPropertyChanged(); }
        }

        public FlowDirection PageDirection { get; set; }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged(); }
        }


        private async void DataGetter()
        {
            TubeServices ser = new TubeServices();
            AllNews = await ser.GetAllNews();
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(DataGetter);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
