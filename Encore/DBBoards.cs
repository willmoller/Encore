using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class DBBoards
    {

        public static DataSet SelectSqlRows(string connectionString,
            string queryString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);

                //code to modify data in DataSet here

                builder.GetUpdateCommand();

                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet, tableName);

                return dataSet;
            }
        }


        public List<string> GetBoard()
        {
            List<string> results = new List<string>();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string command = 
                "SELECT ?" +
                "FROM [table]" +
                "WHERE ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add((string)reader[0]);
                        }
                    }
                }
            }
            return results;
        }
        
        
            

    }
}
