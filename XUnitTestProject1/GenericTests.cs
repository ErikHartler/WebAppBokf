
using EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppCRUD.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    public class GenericTests : AbstractTest
    {
        [Fact]
        public void DbTableIncludesFakturaFakturaRader()
        {
            BokforingContext? db;
            string sql = "";
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

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                Console.Error.WriteLine(sql);
                throw;
            }
        }

  
    }
}
