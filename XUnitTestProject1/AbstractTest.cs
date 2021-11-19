using EFData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace XUnitTestProject1
{
    public class AbstractTest
    {
        protected IConfiguration Configuration { get; set; } = null;
        protected AbstractTest()
        {

        }
        protected IConfiguration LoadConfiguration()
        {
            if (Configuration != null)
            {
                return Configuration;
            }

            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
        protected BokforingContext CreateDbConnection()
        {
            Configuration = LoadConfiguration();

            var connString = Configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<BokforingContext>()
               .UseSqlServer(connString)
               .Options;
            return new BokforingContext(options);
        }

        protected static string ItTook(DateTime start)
        {
            return $"It took { (DateTime.Now - start).TotalMilliseconds} ms";
        }
        protected static void AssertHttpStatusOk(HttpResponseMessage result)
        {
            Assert.True(result.StatusCode == HttpStatusCode.OK, $"Status code is {result.StatusCode} but should be OK");
        }
        protected static void AssertHttpStatusNotFound(HttpResponseMessage result)
        {
            Assert.False (result.StatusCode == HttpStatusCode.OK, $"Status code is {result.StatusCode} but should be OK");
        }
        protected static HttpResponseMessage HttpInvoke(string page)
        {
            using var client = new HttpClient();
            string url = $"http://localhost:51108/{page}";
            HttpResponseMessage result =  client.GetAsync(url).Result;
            return result;
        }


    }
}
