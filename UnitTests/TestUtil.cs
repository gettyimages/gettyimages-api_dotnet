using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace UnitTests
{
    class TestUtil
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
}
