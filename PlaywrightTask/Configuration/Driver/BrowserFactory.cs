using Microsoft.Playwright;
using PlaywrightTask.Core.Configuration;

namespace PlaywrightTask.Configuration.Driver
{
    public class BrowserFactory : IBrowserFactory
    {
        private List<IBrowserHandler> _listOfBrowserHandlers = new List<IBrowserHandler>();

        public void RegisterHandler(IBrowserHandler handler)
        {
            if (!_listOfBrowserHandlers.Contains(handler))
            {
                _listOfBrowserHandlers.Add(handler);
            }
        }       

        public async Task<IBrowser> GetBrowser()
        {
            var browser = SettingsReader.GetBrowserSetting();
            var headless = SettingsReader.GetHeadlessSetting();           

            var handler = _listOfBrowserHandlers.FirstOrDefault(h => h.IsApplicable(browser));

            if (handler == null)
            {
                throw new InvalidOperationException($"Not supported browser: {browser}");
            }

            var browserInstance = await handler.CreateBrowser(headless);
            return  browserInstance;
        }
    }
}
