// Example: Hooks/Hooks.cs
using TechTalk.SpecFlow;

namespace IntegrationTests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize resources, e.g., database connections, mock services
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Clean up resources
        }
    }
}
