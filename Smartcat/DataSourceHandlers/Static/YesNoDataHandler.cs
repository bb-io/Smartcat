using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static
{
    public class YesNoDataHandler : IStaticDataSourceHandler
    {
        protected Dictionary<string, string> EnumValues => new()
    {
        {"true", "Yes"},
        {"false", "No"}
    };

        public Dictionary<string, string> GetData()
        {
            return EnumValues;
        }
    }
}
