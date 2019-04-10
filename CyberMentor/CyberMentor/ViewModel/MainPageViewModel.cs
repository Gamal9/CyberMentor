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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                IsRunning = true;
                Visable = false;
                DataVisable = !Visable;
                PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                DataGetter();
                IsRunning = false;
            }
            else
            {
                Visable = true;
                DataVisable = !Visable;
            }
        }

        public bool DataVisable { get; set; }

        private bool _visable;
        public bool Visable
        {
            get { return _visable; }
            set { _visable = value;OnPropertyChanged(); }
        }


        public FlowDirection PageDirection { get; set; }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CatModel> _categories;

        public ObservableCollection<CatModel> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(); }
        }


        private async void DataGetter()
        {
            TubeServices ser = new TubeServices();
            Categories = await ser.AllCategories();
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
