using Microsoft.Playwright;
using PlaywrightTask.Pages;

namespace PlaywrightTask.Core.Services
{
    public class MainPageService : IMainPageService
    {        
        private IMainPage _mainPage;      

        public MainPageService(IMainPage mainPage)
        {
            _mainPage = mainPage;
        }  
        
        public async Task NavigateToMainPage(IPage page)
        {           
            await page.GotoAsync("https://www.epam.com");
        }

        public async Task SearchAsync(string text)
        {
            await _mainPage.SearchIcon.ClickAsync();
            await _mainPage.SearchField.FillAsync(text);
            await _mainPage.FindButton.ClickAsync();
        }

        public async Task<List<ILocator>> GetSearchResult()
        {
            var count = await _mainPage.SearchResult.CountAsync();
            var result = new List<ILocator>();

            for (int i = 0; i < count; i++)
            {
                result.Add(_mainPage.SearchResult.Nth(i));
            }
            return result;
        }

        public async Task NavigateToAboutPage()
        {
            await _mainPage.AboutLink.ClickAsync();
        }
    }
}
