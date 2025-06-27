using RentalCommon;
using Microsoft.Data.SqlClient;

namespace CampingDeckDL
{
    public class DBDataService : IRentalDataService
    {

        static string connectionString
    = "Data Source = LAPTOP-PJN3L9GN\\SQLEXPRESS; Initial Catalog = CampingRental; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBDataService() 
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<CampingCommon> GetItems()
        {
            var items = new List<CampingCommon>();
            string selectStatement = "SELECT Borrower, Item, Quantity FROM DBRentalDetails";

            using (var command = new SqlCommand(selectStatement, sqlConnection))

            {
                sqlConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     var item = new CampingCommon

                        {
                            Borrower = reader["Borrower"].ToString(),
                            ItemName = reader["Item"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                        items.Add(item);
                    }
                }
                sqlConnection.Close();
            }
            return items;
        }

        public List<CampingCommon> Load()
        {
            return GetItems();
        }

        public void Save(List<CampingCommon> items)
        {
            sqlConnection.Open();
            foreach (var item in items)
            {
                var insertStatement = "INSERT INTO DBRentaldetails (Borrower, Item, Quantity) VALUES (@Borrower, @Item, @Quantity)";
                using (var command = new SqlCommand(insertStatement, sqlConnection))
                {
                    command.Parameters.AddWithValue("@Borrower", item.Borrower);
                    command.Parameters.AddWithValue("@Item", item.ItemName);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }

        public void UpdateItem(CampingCommon item)
        {
            string updateStatement = "UPDATE DBRentalDetails SET Quantity = @Quantity, Borrower = @Borrower WHERE Item = @Item";

            using (var command = new SqlCommand(updateStatement, sqlConnection))
            {
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Borrower", item.Borrower);
                command.Parameters.AddWithValue("@Item", item.ItemName);
                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}