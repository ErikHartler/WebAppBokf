using EFData;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EftestMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BokforingContext? db;
            string sql="";
            try 
            {
                db = CreateDbConnection();
                foreach (var item in db.Model.GetEntityTypes())
                {
                    var entityType = item.GetType();    
                    if (string.IsNullOrEmpty(item.GetTableName()))
                    {
                        sql = $"Select * from {item.Name.Split('.')[1]}";
                    }
                    else
                    {
                        sql = $"Select * from {item.GetTableName()}";
                    }
             
                    db.Database.ExecuteSqlRaw(sql);
                  
                }

            } catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Console.Error.WriteLine(sql);
                throw;
            }
          
            
            
        }

        private IConfiguration? Configuration { get; set; }
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

            var connString = Configuration.GetConnectionString("Bokf");
            var options = new DbContextOptionsBuilder<BokforingContext>()
               .UseSqlServer(connString)
               .Options;
            return new BokforingContext(options);
        }
    }
}