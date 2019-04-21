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
            IsRunning = true;
            MainVisable = true;
            VisableError = false;
            PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            DataGetter();
            IsRunning = false;
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

        private string _ErrorValue;
        public string ErrorValue
        {
            get { return _ErrorValue; }
            set { _ErrorValue = value; OnPropertyChanged(); }
        }

        public bool VisableError { get; set; }
        public bool MainVisable { get; set; }

        public string Nname { get; set; }

        private async void DataGetter()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                Categories = await ser.AllCategories();
                if (Categories.Count == 0)
                {
                    MainVisable = false;
                    VisableError = true;
                    ErrorValue = Resource.NoBuildings;
                }
                else foreach (var item in Categories)
                {
                    item.name = (AppSettings.LastUserGravity == "Arabic") ? item.ar_name : item.en_name;
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
