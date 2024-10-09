using Microsoft.Playwright;

namespace PlaywrightTask.Configuration.Driver
{
    public class EdgeBrowserHandler : IBrowserHandler
    {
        public bool IsApplicable(Enums.Browser browser)
        {
            return browser == Enums.Browser.Edge;
        }

        public async Task<IBrowser> CreateBrowser(bool headless)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = headless
            });
            return browser;
        }
    }
}
