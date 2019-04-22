using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
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
            MainVisable = true;
            VisableError = false;
            PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            DataGetter();
            IsRunning = false;
        }

        private string _ErrorValue;
        public string ErrorValue
        {
            get { return _ErrorValue; }
            set { _ErrorValue = value; OnPropertyChanged(); }
        }

        public bool VisableError { get; set; }
        public bool MainVisable { get; set; }

        private ObservableCollection<CyberNewsModel> _news;
        public ObservableCollection<CyberNewsModel> AllNews
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
            if (CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                AllNews = await ser.GetAllNews();
                if (AllNews.Count == 0)
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
            IsRunning = false;
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
