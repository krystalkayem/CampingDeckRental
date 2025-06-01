using RentalCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace CampingDeckDL
{
    public class DBDataService : IRentalDataService
    {

        static string connectionString
    = "Data Source =; Initial Catalog = CampingRental; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<CampingCommon> GetItems()
        {
            string selectStatement = "SELECT Name, Item, Quantity";
            sqlCommand selectCommand = new sqlCommand(selectStatement), sqlConnection;

            sqlConnection.Open();


            //jijij

            SqlDataReader reader = selectCommand.ExecuteReader();
            List<CampingCommon> items = new List<CampingCommon>();
            while (reader.Read())
            {
                Name = reader["Name"].ToString();
                Item = reader["Item"].ToString();
                Quantity = Convert.ToInt32(reader["Quantity"]);
            }
            ;
            items.Add(item);
        }


        public void UpdateItem(CampingCommon item)
        {
            sqlConnection.Open();

            var updateStatement = $"";

            sqlConnection.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}