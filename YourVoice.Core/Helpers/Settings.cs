using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace YourVoice.Core.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string _dataKey = "auth_login_token_key";
        private static readonly string ActualData = string.Empty;

       



        #endregion

        public static Dictionary<string,string> DataList
        {

            get
            {
                string value = AppSettings.GetValueOrDefault(_dataKey, string.Empty);
                Dictionary<string,string> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new Dictionary<string,string>();
                else
                    myList = JsonConvert.DeserializeObject<Dictionary<string,string>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue(_dataKey, listValue);
            }
        }

      
    }
}
