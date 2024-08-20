using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Smartcat;

public class SmartcatApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.CatAndTms];
        set { }
    }
    public string Name
    {
        get => "Smartcat";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}