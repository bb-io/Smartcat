using Smartcat.Base;

namespace Tests.Smartcat
{
    [TestClass]
    public class ProjectActionTests : TestBase
    {
        [TestMethod]
        public async Task ListAllProjects_IsSuccess()
        {
            var action = new Apps.Smartcat.Actions.ProjectActions(InvocationContext);
            var result = await action.ListAllProjects();
            foreach (var project in result.Projects)
            {
                Console.WriteLine($"{project.Id}: {project.name}");
            }
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateProject_IsSuccess()
        {
            var action = new Apps.Smartcat.Actions.ProjectActions(InvocationContext);
            var result = await action.CreateProject(new Apps.Smartcat.Models.Requests.CreateProjectRequest
            {
                WorkflowStages = new List<string> { "LQAReview", "Translation", "Proofreading" },
                Name = "Test Project from API 4",
                Type = "Default",
                Deadline = DateTime.UtcNow.AddDays(7),
                SourceLanguage = "en",
                TargetLanguages = new List<string> { "de" },
                assignToVendor = false,
                TranslationMemoryIds = new List<string> {"2b1b0c3f-aff6-4c66-85ba-dea0a52cc7d0" },
            });
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Assert.IsNotNull(result);
        }
    }
}
