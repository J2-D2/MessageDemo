using System;
using Xunit;
using MessageApi;
using MessageApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;

namespace MessageApi.Test
{
    public class UnitTest1
    {

        [Fact]
        public void Test1() // this test will insure that the demo api response is not null and that it equals the expected result
        {
            AppSettings appSettings = new AppSettings() { Environment = "test", // setup app setings for test
            DBConnectionString = "test connection string goes here" };

            IOptions<AppSettings> options = Options.Create(appSettings);

            var controller = new MessageController(options);
            IActionResult result = controller.GetDemoMessage(); // test the controller's method

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var resultValue = okObjectResult.Value as string;
            Assert.NotNull(resultValue);

            Assert.Matches("Hello World",resultValue); // does result match 'Hello World'?
        }
    }
}
