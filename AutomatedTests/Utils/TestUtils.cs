using System;
using System.Threading.Tasks;
using Flurl.Http;
using Xunit;

namespace AutomatedTests.Utils
{
    public class TestUtils
    {
        //Assert Exception Http Status Code
        public static async Task AssertExceptionHttpStatusCode(Func<Task> testCode, int statusCode)
        {
            var exception = await Record.ExceptionAsync(testCode);
            Assert.NotNull(exception);
            Assert.IsType<FlurlHttpException>(exception);
            var httpException = exception as FlurlHttpException;
            Assert.Equal(statusCode, httpException.StatusCode);
        }
    }
}