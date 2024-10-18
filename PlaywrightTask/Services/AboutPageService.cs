using PlaywrightTask.Pages;

namespace PlaywrightTask.Core.Services
{
    public class AboutPageService : IAboutpageService
    {
        private readonly IAboutPage _page;        

        public AboutPageService(IAboutPage aboutPage)
        {
            _page = aboutPage;
        }

        public async Task<bool> IsHistoryPresent()
        {
            await _page.HistorySection.ScrollIntoViewIfNeededAsync();
            return await _page.HistorySection.IsVisibleAsync();
        }
    }
}
