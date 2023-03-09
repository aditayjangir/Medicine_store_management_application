using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PlaceOrderModule;

namespace SellingModule
{
    public class SellingOption
    {
        static string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";

        public static void Sell(string medicineName, out int batchNumber , out int Quantity, out double Price)
        {
            SqlConnection con = new SqlConnection(credintialString);
            
            SqlCommand cmd1 = new SqlCommand("select * from productTable where productName = @ProductName", con);
            cmd1.Parameters.AddWithValue("@ProductName", medicineName);
            con.Open();
            SqlDataReader DbResult = cmd1.ExecuteReader();
            DbResult.Read();
            int batchNum = Convert.ToInt32(DbResult.GetValue(0));
            int avlQuantity = Convert.ToInt32(DbResult.GetValue(2));
            double rate = Convert.ToDouble(DbResult.GetValue(6));
            int discount = Convert.ToInt32(DbResult.GetValue(3));

            Console.Write("Quantity of Medicine required: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            batchNumber = batchNum;
            Price = rate;
            Quantity = quantity;

            
            //if quantity is insfficent of we are out of stock
            if (avlQuantity == 0 || avlQuantity < quantity)
            {
                PlaceOrder.Order(medicineName);
                return;
            }

            double totalAmount = (rate * quantity)*(discount/100);
            Price = totalAmount;

            Console.WriteLine("For purchase of {0} money to be collected is = {1}", medicineName, totalAmount);
            int remainingQuantity = avlQuantity - quantity;
            con.Close();

            //updating the stock.
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            con.Open();
            cmd2.CommandText = "update productTable set quantity = @Quantity where productId = @Id";
            cmd2.Parameters.AddWithValue("@Quantity", remainingQuantity);
            cmd2.Parameters.AddWithValue("@Id", batchNum);
            int TotalRowsAffected = cmd2.ExecuteNonQuery();
            con.Close();
            return;
        }


    }
}

//we will check if the medicine is expired or not with its batch no.