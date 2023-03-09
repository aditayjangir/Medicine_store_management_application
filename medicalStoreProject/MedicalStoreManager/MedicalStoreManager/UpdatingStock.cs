using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StockUpdateModule
{
    public class UpdatingStock
    {
        public static void updateStock()
        {
            UpdatingItemDetails details = new UpdatingItemDetails();

            Console.Write("Enter Batch Number: ");
            details.batchNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            details.productName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            details.quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Discount: ");
            details.discount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Mfg. Date: ");
            details.mfgDate = Console.ReadLine();

            Console.Write("Enter Exp. Date: ");
            details.expDate = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            details.unitPrice = Convert.ToDouble(Console.ReadLine());

            string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";
            SqlConnection con = new SqlConnection(credintialString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "Insert into productTable values (@Id, @productName, @Quantity, @Discount, @MfgDate, @ExpDate, @UnitPrice)";

            cmd.Parameters.AddWithValue("@Id", details.batchNum);
            cmd.Parameters.AddWithValue("@productName", details.productName);
            cmd.Parameters.AddWithValue("@Quantity", details.quantity);
            cmd.Parameters.AddWithValue("@Discount", details.discount);
            cmd.Parameters.AddWithValue("@MfgDate", details.mfgDate);
            cmd.Parameters.AddWithValue("@ExpDate", details.expDate);
            cmd.Parameters.AddWithValue("@UnitPrice", details.unitPrice);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
