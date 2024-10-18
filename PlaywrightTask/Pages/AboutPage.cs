using Microsoft.Playwright;

namespace PlaywrightTask.Pages
{
    public class AboutPage : IAboutPage
    {
        private readonly IPage _page;
        public ILocator HistorySection => _page.Locator("//*[text()='HISTORY']");

        public AboutPage(IPage page)
        {
            _page = page;
        }
    }
}
