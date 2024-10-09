using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTask.Configuration.Driver
{
    public class ChromeBrowserHandler : IBrowserHandler
    {
        public bool IsApplicable(Enums.Browser browser)
        {
            return browser == Enums.Browser.Chrome;
        }

        public async Task<IBrowser> CreateBrowser(bool headless)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless
            });
            return browser;
        }
    }
}
