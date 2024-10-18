using Microsoft.Playwright;

namespace PlaywrightTask.Pages
{
    public class MainPage : IMainPage
    {

        private readonly IPage _page;

        public ILocator SearchIcon => _page.Locator("xpath=//*[@class='header-search__button header__icon']");
        public ILocator SearchField => _page.Locator("#new_form_search");
        public ILocator FindButton => _page.Locator(".bth-text-layer");
        public ILocator CookiePolicyAcceptButton => _page.Locator("#onetrust-accept-btn-handler");
        public ILocator CookiePolicyBanner => _page.Locator("#onetrust-banner-sdk");
        public ILocator SearchResult => _page.Locator(".search-results__item");
        public ILocator AboutLink => _page.Locator("li >> a.top-navigation__item-link.js-op").Filter(new() { HasText = "About" });

        public MainPage(IPage page)
        {
            _page = page;
        }
    }
}
