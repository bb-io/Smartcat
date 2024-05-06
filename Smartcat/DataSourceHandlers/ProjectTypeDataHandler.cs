using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.DataSourceHandlers
{
    public class ProjectTypeDataHandler : BaseInvocable, IDataSourceHandler
    {
        public ProjectTypeDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var projectType = new List<string>
        {
             "Default",
             "SoftwareLocalization"
        };

            return projectType
                .Where(projectType => context.SearchString == null || projectType.Contains(context.SearchString,
                    StringComparison.OrdinalIgnoreCase))
                .ToDictionary(projectType => projectType, projectType => projectType);
        }

    }
}
