using Microsoft.Playwright;

namespace PlaywrightTask.Pages
{
    public interface IMainPage
    {
        ILocator SearchIcon { get; }
        ILocator SearchField { get; }
        ILocator FindButton { get; }
        ILocator SearchResult { get; }
        ILocator AboutLink { get; }
        ILocator CookiePolicyAcceptButton { get; }
        ILocator CookiePolicyBanner { get; }
    }
}
