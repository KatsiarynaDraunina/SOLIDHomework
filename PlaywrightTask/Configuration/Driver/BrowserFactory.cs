using Microsoft.Playwright;

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

        public IBrowser GetBrowser(Enums.Browser browser, bool headless)
        {
            
            var handler = _listOfBrowserHandlers.FirstOrDefault(h => h.IsApplicable(browser));

            if (handler == null)
            {
                throw new InvalidOperationException($"Not supported browser: {browser}");
            }

            return (IBrowser)handler.CreateBrowser(headless);
        }
    }
}
