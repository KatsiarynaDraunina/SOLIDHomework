using Microsoft.Playwright;
using PlaywrightTask.Core.Pages;

namespace PlaywrightTask.Core.Services
{
    public class PageServiceFactory : IPageServiceFactory
    {
        private readonly IPageFactory _pageFactory;      

        public PageServiceFactory(IPage page)
        {
            _pageFactory = new PageFactory(page);           
        }

        public MainPageService GetMainPageService()
        {
            return new MainPageService(_pageFactory.GetMainPage());
        }

        public AboutPageService GetAboutPageService()
        {
            return new AboutPageService(_pageFactory.GetAboutPage());
        }
    }
}
