using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StockUpdateModule
{
    public class ReturnMedicine
    {
        public static void Return()
        {
            //sql credintial string
            string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";

            // now to return medicine we will check its batch number from our database if exist then we will take it back
            Console.Write("Enter medicine Batch Number: ");
            int returnedMedicineBatchNumber = Convert.ToInt32(Console.ReadLine());
            
            // Note* we have to make seprate list that store all the batch number of current or out of stock medicines.
            // or what we can do is like we did in hr-utility-tool that shows if quantity column is 0 than do not select that row while retriving data from database.
            SqlConnection con = new SqlConnection(credintialString);
            SqlCommand cmd1 = new SqlCommand("select * from productTable where productId = @ProductId", con);
            cmd1.Parameters.AddWithValue("@ProductId", returnedMedicineBatchNumber);
            con.Open();
            SqlDataReader DbResult = cmd1.ExecuteReader();
            DbResult.Read();
            int avlQuantity = Convert.ToInt32(DbResult.GetValue(2));
            int batchNum = Convert.ToInt32(DbResult.GetValue(0));
            if (Convert.ToInt32(DbResult.GetValue(0)) == returnedMedicineBatchNumber)
            {
                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                int newTotal = avlQuantity + quantity;
                con.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandText = "update productTable set quantity = @Quantity where productId = @Id";
                cmd2.Parameters.AddWithValue("quantity", newTotal);
                cmd2.Parameters.AddWithValue("@Id", batchNum);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            //else we will not.
            else
            {
                Console.WriteLine("This medicine was not purchased from our store");
            }
        }
    }
}
