using CommonLibs.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Test
{
    [TestClass]
    public class DatabaseTest
    {
        DatabaseUtils dbUtils;
        

        [TestInitialize]
        public void Setup()
        {
            dbUtils = new DatabaseUtils();
            dbUtils.CreateConnection();
        }
        [TestMethod]
        public void VerifySelectData()
        {
            var sqlQuery = "select * from table_name";
            var dataTable = dbUtils.ExecuteSelectQuery(sqlQuery);
            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["col2"]);
            }
        }
        [TestMethod]
        public void VerifyNoNSelectData()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Insert into");
            builder.Append("Insert query 1 continuation...");
            string sqlQuery = builder.ToString();
            int rowsAffected = dbUtils.ExecuteNoNSelectQuery(sqlQuery);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbUtils.CloseConnection();
        }
    }
}
