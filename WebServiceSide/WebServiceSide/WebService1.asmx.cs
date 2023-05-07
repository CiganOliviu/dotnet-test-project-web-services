using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace WebServiceSide
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public SqlConnection GetDatabaseConnection() 
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\FACULTATE\\AN3SEM2\\II\\LAB7-LAB8\\PROJECT\\DOTNET-TEST-PROJECT-WEB-SERVICES\\WEBSERVICESIDE\\WEBSERVICESIDE\\APP_DATA\\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
            };

            return connection;
        }

        [WebMethod]
        public void AddDataInProjectTable(SqlConnection connection, string projectName)
        {
            string query = "INSERT INTO Project (name, created_at) VALUES (@name, @created_at)";
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", projectName); // Replace with your actual parameter values
                command.Parameters.AddWithValue("@Value2", DateTime.Now.ToString());

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
        }

        [WebMethod]
        public List<string> GetAllProjectsByName(SqlConnection connection)
        {
            string query = "SELECT Name FROM Project";
            connection.Open();
            List<string> result = new List<string>();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0); 
                        result.Add(name);
                    }
                }
            }

            return result;
        }

        [WebMethod]
        public void DeleteDataInProjectTableById(SqlConnection connection, int id)
        {
            string query = "DELETE FROM Project WHERE Id = @Id";
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
        }
    }
}
