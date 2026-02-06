namespace UnitTests;

internal class TestUtil
{
    public static TestHandler CreateTestHandler()
    {
        return new TestHandler(new
        {
            images = new[]
            {
                new { }
            }
        });
    }
}
