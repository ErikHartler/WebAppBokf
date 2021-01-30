
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppCRUD.Controllers;
using WebAppCRUD.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class AbstractTest
    {
        protected string  ItTook(DateTime start)
        {
            return $"It took { (DateTime.Now - start).TotalMilliseconds} ms";
        }
        protected void AssertHttpStatusOk(HttpResponseMessage result)
        {
            Assert.True(result.StatusCode == HttpStatusCode.OK, $"Status code is {result.StatusCode} but should be OK");
        }
        protected void AssertHttpStatusNotFound(HttpResponseMessage result)
        {
            Assert.True(result.StatusCode == HttpStatusCode.OK, $"Status code is {result.StatusCode} but should be OK");
        }
        protected HttpResponseMessage HttpInvoke(string page)
        {
            using var client = new HttpClient();
            string url = $"http://localhost:51108/{page}";
            HttpResponseMessage result =  client.GetAsync(url).Result;
            return result;
        }


    }
}
