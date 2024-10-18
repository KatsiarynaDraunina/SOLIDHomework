using Microsoft.Playwright;
using PlaywrightTask.Enums;

namespace PlaywrightTask.Configuration.Driver
{
    public class ChromeBrowserHandler : IBrowserHandler
    {
        public bool IsApplicable(Browser browser)
        {
            return browser == Browser.Chrome;
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
