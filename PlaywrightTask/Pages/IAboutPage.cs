using Microsoft.Playwright;

namespace PlaywrightTask.Pages
{
    public interface IAboutPage
    {
        ILocator HistorySection { get; }
    }
}
