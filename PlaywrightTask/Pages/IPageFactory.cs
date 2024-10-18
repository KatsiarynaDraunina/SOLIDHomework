using PlaywrightTask.Pages;

namespace PlaywrightTask.Core.Pages
{
    public interface IPageFactory
    {
        //Task<MainPage> CreateAsync(IPage page);
        IAboutPage GetAboutPage();
        IMainPage GetMainPage();
    }
}