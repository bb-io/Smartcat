using Apps.Smartcat.DataSourceHandlers;
using Smartcat.Base;

namespace Tests.Smartcat
{
    [TestClass]
    public class DataSources : TestBase
    {
        [TestMethod]
        public async Task ProjectDataHandler_IsSuccess()
        {
            var handler = new ProjectDataHandler(InvocationContext);

            var result = await handler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
                SearchString = null
            }, CancellationToken.None);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TMDataHandler_IsSuccess()
        {
            var handler = new TMDataHandler(InvocationContext);

            var result = await handler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
                SearchString = null
            }, CancellationToken.None);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Assert.IsNotNull(result);
        }
    }
}
