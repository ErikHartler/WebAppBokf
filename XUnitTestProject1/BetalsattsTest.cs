
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
    public class BetalsattsTest : AbstractTest
    {
        [Fact]
        public void DbTableIncludesFakturaFakturaRader()
        {
            var start = DateTime.Now;
            int i = 0;
            for (int j=0; j < 10; j++)
            {

                using (var  context = new BokforingContext())
                {
                    var betalsattList = 
                        context.
                        Betalsatt.
                        AsNoTracking().
                        ToList();
                    foreach(var faktura in betalsattList)
                    {
                        i++;
                    }
                }
                Assert.True(i>0);
                Console.WriteLine($"{ItTook(start)}");
            }
        }

        [Fact]
        public  void IndexControllerExecutesToCompletion()
        {
            var start = DateTime.Now;
            using (var context = new BokforingContext())
            {
                using (var ctrl = new BetalsattsController(context)) 
                {
                    var resultAsync = ctrl.Index();
                    resultAsync.Wait();                   
                    Assert.True(resultAsync.Status == TaskStatus.RanToCompletion,$"Task Status:{resultAsync.Status}");
                }
            }

            Console.WriteLine($"{ItTook(start)}"); ;
        }


        [Fact]
        public void DetailsControllerExecutesToCompletion()
        {
            var start = DateTime.Now;
            using (var context = new BokforingContext())
            {
                var betalsatt =
                        context.
                        Betalsatt.
                        AsNoTracking().
                        FirstOrDefault();
                using (var ctrl = new BetalsattsController(context))
                {
                    var resultAsync = ctrl.Details(betalsatt.Betalsatt1);
                    resultAsync.Wait();
                    Assert.True(resultAsync.Status == TaskStatus.RanToCompletion, $"Task Status:{resultAsync.Status}");
                }
            }

            Console.WriteLine($"{ItTook(start)}");
        }

        [Fact]
        public void HttpInvokeFakturasTop()
        {
            var start = DateTime.Now;
            HttpResponseMessage result = HttpInvoke("Betalsatts");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            AssertHttpStatusOk(result);
        }

        [Fact]
        public void HttpInvokeFakturasIndex()
        {
            var start = DateTime.Now;
            HttpResponseMessage result =HttpInvoke("Betalsatts/Index");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            AssertHttpStatusOk(result);
        }

        [Fact]
        public void HttpInvokeDetailsOnIdThatExists()
        {
            var start = DateTime.Now;
            using (var context = new BokforingContext())
            {
                var betalsatt =
                        context.
                        Betalsatt.
                        AsNoTracking().
                        FirstOrDefault();
              
                HttpResponseMessage result = HttpInvoke($"Betalsatts/Details/{betalsatt.Betalsatt1}");
                Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
                AssertHttpStatusOk(result);
            }
        }

        [Fact]
        public void HttpInvokeDetailsOnIdThatDoesNotExists()
        {
            var start = DateTime.Now;
            HttpResponseMessage result = HttpInvoke("Betalsatts/Details/9999");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            AssertHttpStatusNotFound(result);
        }


        [Fact]
        public void HttpInvokeDetailsOnPageThatDoesNotExists()
        {
            var start = DateTime.Now;
            HttpResponseMessage result = HttpInvoke("Betalsatts/Detailsxx/9999");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            AssertHttpStatusNotFound(result);
        }
    }
}
