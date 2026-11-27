
using EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebAppCRUD.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    public class FakturorTest:AbstractTest
    {
        [Fact]
        public void DbTableIncludesFakturaFakturaRader()
        {
            var start = DateTime.Now;
            int i = 0;
            for (int j=0; j < 10; j++)
            {

                using (var  context = CreateDbConnection())
                {
                    var fakturor = 
                        context.
                        Faktura.
                        AsNoTracking().
                        Include(r=>r.Fakturarads).
                        ToList();
                    foreach(var faktura in fakturor)
                    {
                        foreach (var rad in faktura.Fakturarads)
                        {
                            i++;
                        }
                    }
                }
               
                Console.WriteLine($"{ItTook(start)}");
            }
        }

        [Fact]
        public async Task IndexControllerExecutesToCompletion()
        {
            var start = DateTime.Now;
            BokforingContext context = null;
            FakturasController ctrl;
            try
            {
                context = CreateDbConnection();
                var betalsatt =
                        context.
                        Betalsatt.
                        AsNoTracking().
                        FirstOrDefault();
                ctrl = new FakturasController(context);
                var resultAsync = ctrl.Index();
                await resultAsync.WaitAsync(CancellationToken.None);
                Assert.True(resultAsync.Status == TaskStatus.RanToCompletion, $"Task Status:{resultAsync.Status}");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        

            Console.WriteLine($"{ItTook(start)}"); ;
        }


        [Fact]
        public async Task DetailsControllerExecutesToCompletion()
        {
            var start = DateTime.Now;
            BokforingContext context = null;
            FakturasController ctrl;
            try
            {
                context = CreateDbConnection();
                var betalsatt =
                        context.
                        Betalsatt.
                        AsNoTracking().
                        FirstOrDefault();
                ctrl = new FakturasController(context);
                var resultAsync = ctrl.Details(1);
                await resultAsync.WaitAsync(CancellationToken.None);
                Assert.True(resultAsync.Status == TaskStatus.RanToCompletion, $"Task Status:{resultAsync.Status}");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            

            Console.WriteLine($"{ItTook(start)}");
        }

        [Fact]
        public void HttpInvokeFakturasTop()
        {
            var start = DateTime.Now;
            var result = HttpInvoke("Fakturas");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            Assert.True(result.StatusCode == HttpStatusCode.OK,$"Status code is {result.StatusCode} but should be OK");
        }

        [Fact]
        public void HttpInvokeFakturasIndex()
        {
            var start = DateTime.Now;
            var result =HttpInvoke("Fakturas/Index");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            Assert.True(result.StatusCode == HttpStatusCode.OK, $"Status code is {result.StatusCode} but should be OK");
        }

        [Fact]
        public void HttpInvokeDetailsOnIdThatExists()
        {
            var start = DateTime.Now;            
            var result = HttpInvoke("Fakturas/Details/1");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            
        }

        [Fact]
        public void HttpInvokeDetailsOnIdThatDoesNotExists()
        {
            var start = DateTime.Now;
            var result = HttpInvoke("Fakturas/Details/9999");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            Assert.True(result.StatusCode == HttpStatusCode.NotFound, $"Status code is {result.StatusCode} but should be NotFound");
        }


        [Fact]
        public void HttpInvokeDetailsOnPageThatDoesNotExists()
        {
            var start = DateTime.Now;
            var result = HttpInvoke("Fakturas/Detailsxx/9999");
            Console.WriteLine($"Status:{result.StatusCode}. {ItTook(start)}");
            Assert.True(result.StatusCode == HttpStatusCode.NotFound, $"Status code is {result.StatusCode} but should be NotFound");
        }
    }
}
