using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightTask.Configuration.Driver;
using PlaywrightTask.Core.Services;

namespace PlaywrightTask.Tests
{
    public abstract class TestBase
    {          
        protected IBrowser Browser { get; private set; }
        protected IPage Page { get; private set; }        
        protected IPageServiceFactory PageServiceFactory { get; private set; }       

        private async Task BuildBrowser()
        {
            var browserFactory = new BrowserFactory();
            browserFactory.RegisterHandler(new ChromeBrowserHandler());
            browserFactory.RegisterHandler(new EdgeBrowserHandler());
            Browser = await browserFactory.GetBrowser();            
        }

        private async Task CreatePageServiceFactory()
        {
            Page = await Browser.NewPageAsync();
            PageServiceFactory = new PageServiceFactory(Page);
        }

        [SetUp]
        public async Task SetUpTest()
        {          
            await BuildBrowser();
            await CreatePageServiceFactory();
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
            }
        }
    }
}
