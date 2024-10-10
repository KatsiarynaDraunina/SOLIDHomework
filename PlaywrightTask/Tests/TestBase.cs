using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTask.Configuration.Driver;
using PlaywrightTask.Pages;

namespace PlaywrightTask.Tests
{
    public abstract class TestBase
    {      
        protected IServiceProvider ServiceProvider { get; private set; }
        protected IBrowser Browser { get; private set; }
        protected IPage Page { get; private set; }
              

        private void BuildProvider(IServiceCollection services)
        {
            services.AddSingleton<IBrowserFactory, BrowserFactory>();
            services.AddScoped<IBrowserHandler,EdgeBrowserHandler>();
            services.AddScoped<IBrowserHandler, ChromeBrowserHandler>();
            services.AddTransient<MainPage>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private async Task BuildBrowser()
        {
            var browserFactory = ServiceProvider.GetRequiredService<IBrowserFactory>();
            Browser = await browserFactory.GetBrowser();
            Page = await Browser.NewPageAsync();
        }

        [SetUp]
        public void SetUpTest()
        {
           // BuildProvider();
        }
    }
}
