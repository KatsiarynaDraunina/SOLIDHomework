using Microsoft.Playwright;

namespace PlaywrightTask.Configuration.Driver
{
    public interface IBrowserFactory
    {
        void RegisterHandler(IBrowserHandler handler);
        IBrowser GetBrowser(Enums.Browser browser, bool headless);
    }
}
