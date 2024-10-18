using Microsoft.Playwright;

namespace PlaywrightTask.Core.Services
{
    public interface IMainPageService
    {
        Task SearchAsync(string text);
        Task<List<ILocator>> GetSearchResult();
    }
}
