using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTask.Pages
{
    public class MainPage
    {
        private readonly IPage _page;
        private readonly ILocator _searchIcon;
        private readonly ILocator _searchField;
        private readonly ILocator _findButton;
        private readonly ILocator _cookiePolicyAcceptButton;
        private readonly ILocator _cookiePolicyBanner;        

        public MainPage(IPage page)
        {
            _page = page;
            _searchIcon = page.Locator("xpath=//*[@class='header-search__button header__icon']");
            _searchField = page.Locator("#new_form_search");
            _findButton = page.Locator(".bth-text-layer");
            _cookiePolicyAcceptButton = page.Locator("#onetrust-accept-btn-handler");
            _cookiePolicyBanner = page.Locator("#onetrust-banner-sdk");
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://www.epam.com");            
        }

        //public async Task AcceptCookiesAsync(IPage page)
        //{            
        //    if (await page.IsVisibleAsync(_cookiePolicyBanner))
        //    {
        //        await page.ClickAsync(acceptButtonSelector);
        //    }
        //}

       
        public async Task SearchAsync(string text)
        {
            await _searchIcon.ClickAsync();
            await _searchField.FillAsync(text);
            await _findButton.ClickAsync();
        }
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
