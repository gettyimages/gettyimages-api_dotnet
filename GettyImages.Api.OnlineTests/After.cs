using System.Threading;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests
{
    public class After
    {
        [AfterScenario]
        public static void AfterScenarioAttribute()
        {
            Thread.Sleep(200);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Thread.Sleep(500);
        }
    }
}