using Microsoft.Playwright;

namespace PlaywrightTask.Configuration.Driver
{
    public interface IBrowserFactory
    {
        void RegisterHandler(IBrowserHandler handler);
        Task<IBrowser> GetBrowser();
    }
}
