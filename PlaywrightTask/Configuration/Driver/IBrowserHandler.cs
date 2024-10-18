using Microsoft.Playwright;

namespace PlaywrightTask.Configuration.Driver
{
    public interface IBrowserHandler
    {
        bool IsApplicable(Enums.Browser browser);
        Task<IBrowser> CreateBrowser(bool headless);
    }
}
