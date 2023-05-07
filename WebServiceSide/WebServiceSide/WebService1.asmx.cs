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
    }
}
