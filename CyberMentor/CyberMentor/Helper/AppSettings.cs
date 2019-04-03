using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Helper
{
    public static class AppSettings
    {
        private static ISettings Settings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private const string LastEmailSettingsKey = "last_email_key";
        private static readonly string SettingsDefault = string.Empty;
        public static string LastUsedEmail
        {
            get
            =>
                 Settings.GetValueOrDefault(LastEmailSettingsKey, SettingsDefault);


            set
            =>
                Settings.AddOrUpdateValue(LastEmailSettingsKey, value);

        }

        private const string ProfileId = "last_email_key";
        private static readonly string SettingsProfileId = string.Empty;
        public static string LastProfileID
        {
            get
            =>
                 Settings.GetValueOrDefault(ProfileId, SettingsProfileId);


            set
            =>
                Settings.AddOrUpdateValue(ProfileId, value);

        }

        private const string LastSignalIDSettingKey = "last_email_key";
        private static readonly string SignalID = string.Empty;
        public static string LastSignalID
        {
            get
            =>
                 Settings.GetValueOrDefault(LastSignalIDSettingKey, SignalID);


            set
            =>
                Settings.AddOrUpdateValue(LastSignalIDSettingKey, value);

        }

        //private const string LastServiceSettingsKey = "last_service_key";
        //private static readonly string ServiceSettingsDefault = string.Empty;
        //public static string LastUsedService
        //{
        //    get
        //    =>
        //         AppSettings.GetValueOrDefault(LastServiceSettingsKey, ServiceSettingsDefault);


        //    set
        //    =>
        //        AppSettings.AddOrUpdateValue(LastServiceSettingsKey, value);

        //}

        private const string LastRoleSettingsKey = "last_role_key";
        private static readonly int SettingsRole = 0;
        public static int LastUseeRole
        {
            get
            =>
                 Settings.GetValueOrDefault(LastRoleSettingsKey, SettingsRole);


            set
            =>
                Settings.AddOrUpdateValue(LastRoleSettingsKey, value);

        }

        private const string LastGravity = "last_Gravity_key";
        private static readonly string GravitySettings = string.Empty;
        public static string LastUserGravity
        {
            get
            =>
                 Settings.GetValueOrDefault(LastGravity, GravitySettings);


            set
            =>
                Settings.AddOrUpdateValue(LastGravity, value);

        }

        private const string LastUserHash = "User_Hash";
        private static readonly string UserHashDefault = string.Empty;
        public static string UserHash
        {
            get
            =>
                 Settings.GetValueOrDefault(LastUserHash, UserHashDefault);


            set
            =>
                Settings.AddOrUpdateValue(LastUserHash, value);

        }

        private const string LastUserFirebaseToken = "Firebase_Token";
        private static readonly string LastFirebaseToken = string.Empty;
        public static string UserFirebaseToken
        {
            get
            =>
                 Settings.GetValueOrDefault(LastUserFirebaseToken, LastFirebaseToken);


            set
            =>
                Settings.AddOrUpdateValue(LastUserFirebaseToken, value);

        }


        private const string PublicParamter = "PublicParamter";
        private static readonly string ParamSettings = string.Empty;
        public static string LastPublicParamter
        {
            get
            =>
                 Settings.GetValueOrDefault(PublicParamter, ParamSettings);


            set
            =>
                Settings.AddOrUpdateValue(PublicParamter, value);

        }

        private const string SecondParamter = "SecondParamter";
        private static readonly string SecondSettings = string.Empty;
        public static string LastSecondParamter
        {
            get
            =>
                 Settings.GetValueOrDefault(SecondParamter, SecondSettings);


            set
            =>
                Settings.AddOrUpdateValue(SecondParamter, value);

        }


        private const string LastIDSettingsKey = "last_ID_key";
        private static readonly int SettingsIDDefault = 0;
        public static int LastUsedID
        {
            get => Settings.GetValueOrDefault(LastIDSettingsKey, SettingsIDDefault);
            set => Settings.AddOrUpdateValue(LastIDSettingsKey, value);

        }

        private const string LastServiceID = "last_ID_key";
        private static readonly int SettingsServiceID = 0;
        public static int LastServeceIDParam
        {
            get => Settings.GetValueOrDefault(LastServiceID, SettingsServiceID);
            set => Settings.AddOrUpdateValue(LastServiceID, value);

        }

        private const string _countryID = "last_Country";
        private static readonly int SettingsCountriesDefault = 0;
        public static int LastCountry
        {
            get => Settings.GetValueOrDefault(_countryID, SettingsCountriesDefault);
            set => Settings.AddOrUpdateValue(_countryID, value);

        }

        private const string _cityID = "last_City";
        private static readonly int SettingsCityDefault = 0;
        public static int LastCity
        {
            get => Settings.GetValueOrDefault(_cityID, SettingsCityDefault);
            set => Settings.AddOrUpdateValue(_cityID, value);

        }

    }

}
