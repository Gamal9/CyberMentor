using CyberMentor.Model;
using CyberMentor.Service;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CyberMentor.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            IsRunning = true;
            MainVisable = true;
            VisableError = false;
            DataGetter();
            IsRunning = false;
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged(); }
        }

        private string _ErrorValue;
        public string ErrorValue
        {
            get { return _ErrorValue; }
            set { _ErrorValue = value; OnPropertyChanged(); }
        }

        public bool VisableError { get; set; }
        public bool MainVisable { get; set; }

        private SettingsModel _settings;
        public SettingsModel AllSettings
        {
            get { return _settings; }
            set { _settings = value; OnPropertyChanged(); }
        }


        private async void DataGetter()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                AllSettings = await ser.GetSettings();
                if (AllSettings.id == 0)
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
