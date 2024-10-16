using Microsoft.Playwright;
using PlaywrightTask.Pages;

namespace PlaywrightTask.Core.Pages
{
    public class PageFactory : IPageFactory
    {
        private readonly IPage _page;

        public PageFactory(IPage page)
        {
            _page = page;
        }

        public async Task<MainPage> CreateAsync(IPage page)
        {
            var mainPage = new MainPage(page);
            await page.GotoAsync("https://www.epam.com");
            return mainPage;
        }

        public IAboutPage GetAboutPage()
        { 
            return new AboutPage(_page);
        }
    }
}
