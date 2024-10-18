namespace PlaywrightTask.Core.Services
{
    public interface IPageServiceFactory
    {
        MainPageService GetMainPageService();
        AboutPageService GetAboutPageService();
    }
}
