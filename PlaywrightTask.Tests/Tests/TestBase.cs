using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTask.Configuration.Driver;
using PlaywrightTask.Core.Pages;
using PlaywrightTask.Core.Services;
using PlaywrightTask.Pages;

namespace PlaywrightTask.Tests
{
    public abstract class TestBase
    {      
        protected IServiceProvider ServiceProvider { get; private set; }
        protected IBrowser Browser { get; private set; }
        protected IPage Page { get; private set; }       

        private void BuildProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IBrowserFactory, BrowserFactory>();
            services.AddScoped<IBrowserHandler,EdgeBrowserHandler>();
            services.AddScoped<IBrowserHandler, ChromeBrowserHandler>();
            services.AddScoped<IMainPage, MainPage>();
            services.AddScoped<IAboutPage, AboutPage>();
            services.AddScoped<IPageFactory, PageFactory>();
            services.AddScoped<IAboutpageService, AboutPageService>();
            services.AddScoped<IMainPageService, MainPageService>();
            services.AddScoped<IPage>(provider => Page);

            ServiceProvider = services.BuildServiceProvider();
        }

        private async Task BuildBrowser()
        {
            var browserFactory = ServiceProvider.GetRequiredService<IBrowserFactory>();            
            var browserHandlers = ServiceProvider.GetServices<IBrowserHandler>();

            foreach (var handler in browserHandlers)
            {
                browserFactory.RegisterHandler(handler);
            }
            Browser = await browserFactory.GetBrowser();
            Page = await Browser.NewPageAsync();
        }

        [SetUp]
        public async Task SetUpTest()
        {
            BuildProvider();
            await BuildBrowser();                            
        }

        [TearDown]
        public async Task TearDownTest()
        {
            try
            {
              
            }
            finally
            {
                await Browser.CloseAsync();               
                ((IDisposable)ServiceProvider).Dispose();
            }
        }
    }
}
