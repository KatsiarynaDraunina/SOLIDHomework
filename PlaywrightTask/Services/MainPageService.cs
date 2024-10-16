using Microsoft.Playwright;
using PlaywrightTask.Pages;

namespace PlaywrightTask.Core.Services
{
    public class MainPageService : IMainPageService
    {
        private readonly IMainPage _page;        

        public MainPageService(IMainPage mainPage)
        {
            _page = mainPage;
        }       

        public async Task SearchAsync(string text)
        {
            await _page.SearchIcon.ClickAsync();
            await _page.SearchField.FillAsync(text);
            await _page.FindButton.ClickAsync();
        }

        public async Task<List<ILocator>> GetSearchResult()
        {
            var count = await _page.SearchResult.CountAsync();
            var result = new List<ILocator>();

            for (int i = 0; i < count; i++)
            {
                result.Add(_page.SearchResult.Nth(i));
            }
            return result;
        }
    }
}
