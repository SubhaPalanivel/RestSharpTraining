using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Utils
{
    public class DatabaseUtils
    {
        //1. Create a connection with Database
        //2. Prepare an SQL Query
        //3. Execute the query - Select(ExecuteReader()) or NoN -select query (ExecuteNonquersy)
        //4. Process the data
        //5. Close the connection

        private SqlConnection connection;

        public void CreateConnection()
        {
            //object initiaization can be simplified as below
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {

                DataSource = "localhost",
                UserID = "Subha",
                Password = "adsfsadf",
                InitialCatalog = "",
                ConnectionString = ""
            };
            connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
        }
        //Express way of writing the method
        public void CloseConnection() => connection.Close();

        public DataTable ExecuteSelectQuery(string SQLQuery)
        {
            SqlCommand command = new SqlCommand(SQLQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }
        public int ExecuteNoNSelectQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int rowAltered = command.ExecuteNonQuery();
            return rowAltered;
        }
      
    }
}
