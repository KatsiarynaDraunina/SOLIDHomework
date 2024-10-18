using NUnit.Framework;
using PlaywrightTask.Core.Services;

namespace PlaywrightTask.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        [TestCase("Cloud")]
        public async Task SearchResultForMainPageContainsSearchItem(string searchTerm)
        {
            var mainPageService = PageServiceFactory.GetMainPageService();

            await mainPageService.NavigateToMainPage(Page);
            await mainPageService.SearchAsync(searchTerm);
            var searchResult = await mainPageService.GetSearchResult();

            var results = new List<string>();

            for (int i = 0; i < searchResult.Count(); i++)
            {                
                results.Add(await searchResult[i].InnerTextAsync());
            }

            results.ForEach(item =>
                Assert.That(item.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase), Is.True, $"{item} should contain {searchTerm}"));           
        }

        [Test]
        public async Task NavigateToAboutPage()
        {
            var mainPageService = PageServiceFactory.GetMainPageService();
            var aboutPageService = PageServiceFactory.GetAboutPageService();

            await mainPageService.NavigateToMainPage(Page);
            await mainPageService.NavigateToAboutPage();
            var isHistoryPresent = await aboutPageService.IsHistoryPresent();

            Assert.That(isHistoryPresent, Is.True, "History section should be present on the About page.");
        }
    }
}
