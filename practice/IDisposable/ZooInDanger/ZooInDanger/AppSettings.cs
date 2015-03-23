#region

using System;
using System.Configuration;

#endregion

namespace Epam.NetMentoring.Zoo
{
    public static class AppSettings
    {
        public static bool IsLoggingEnabled
        {
            get { return String.Equals(ConfigurationSettings.AppSettings["isLoggingEnabled"], "true"); }
        }
    }
}