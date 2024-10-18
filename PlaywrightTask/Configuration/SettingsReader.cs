using PlaywrightTask.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTask.Core.Configuration
{
    public class SettingsReader
    {
        public static Browser GetBrowserSetting()
        {
            Enum.TryParse(ConfigurationManager.AppSettings["browser"], out Browser browser);
            return browser;
        }

        public static bool GetHeadlessSetting()
        {
            bool.TryParse(ConfigurationManager.AppSettings["headless"], out bool headless);
            return headless;
        }        
    }
}
