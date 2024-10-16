using Microsoft.Extensions.DependencyInjection;
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
            var mainPageService = ServiceProvider.GetService<IMainPageService>();
           
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
    }
}
