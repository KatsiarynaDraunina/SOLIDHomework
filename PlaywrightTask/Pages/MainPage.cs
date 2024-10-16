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
        public ILocator AboutLink => _page.Locator("text='About'");

        public MainPage(IPage page)
        {
            _page = page;            
        }


        //private readonly IPage _page;
        //public readonly ILocator _searchIcon;
        //private readonly ILocator _searchField;
        //private readonly ILocator _findButton;
        //private readonly ILocator _cookiePolicyAcceptButton;
        //private readonly ILocator _cookiePolicyBanner;
        //private readonly ILocator _searchResult;
        //private readonly ILocator _aboutLink;


        //public MainPage(IPage page)
        //{
        //    _page = page;
        //    _searchIcon = page.Locator("xpath=//*[@class='header-search__button header__icon']");
        //    _searchField = page.Locator("#new_form_search");
        //    _findButton = page.Locator(".bth-text-layer");
        //    _cookiePolicyAcceptButton = page.Locator("#onetrust-accept-btn-handler");
        //    _cookiePolicyBanner = page.Locator("#onetrust-banner-sdk");
        //    _searchResult = page.Locator(".search-results__item");
        //    _aboutLink = page.Locator("text='About'");
        //}     

    }

    //public class MyWebTest : PageTest // inheriting from PageTest if using Playwright Test Runner
    //{
    //    [Test]
    //    public async Task TestExampleSite()
    //    {
    //        await Page.GotoAsync("https://example.com");

    //        // Call the cookie-handler method right after the page load
    //        await CookieHandler.AcceptCookiesAsync(Page);

    //        // Continue with the rest of your test actions
    //        // ...
    //    }

    }
