using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineNameList;
using PlaceOrderModule;
using ManageNearExpiredMedicineModule;
using System.Data.SqlClient;

namespace SellingModule
{
    public class SellMedicine
    {
        static int ProductId = 0;
        public static void SellMedicineFunction()
        {
            Console.WriteLine("Search Medicine here...");
            String? medName = Console.ReadLine();
            SqlDataReader DbResult = null;
            bool purchase = false;
            int CustomerId = 0;
            

            string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";
            SqlConnection con = new SqlConnection(credintialString);
            SqlCommand cmd1 = new SqlCommand("select * from productTable where productName = @ProductName", con);
            cmd1.Parameters.AddWithValue("@ProductName", medName);
            con.Open();
            DbResult = cmd1.ExecuteReader();

            if (DbResult.Read())
            {
                ProductId = Convert.ToInt32(DbResult.GetValue(0));
                con.Close();
                Console.WriteLine("Medicine available");

                Console.WriteLine("Want to place order Yes or No");
                string userResponce = Console.ReadLine().ToUpper();
                if (userResponce == "YES")
                {

                    CustomerDetails details = new CustomerDetails();

                    Console.WriteLine("Enter FullName");
                    details.Name = Console.ReadLine();

                    Console.WriteLine("Enter Email");
                    details.Email = Console.ReadLine();

                    Console.WriteLine("Enter Mobile");
                    details.Mobile = Convert.ToInt64(Console.ReadLine());


                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    con.Open();
                    cmd2.CommandText = "Insert into customerTable values (@CustName, @CustEmail, @CustMobile)";
                    cmd2.Parameters.AddWithValue("@CustName", details.Name);
                    cmd2.Parameters.AddWithValue("@CustEmail", details.Email);
                    cmd2.Parameters.AddWithValue("@CustMobile", details.Mobile);
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = con;
                    con.Open();
                    cmd3.CommandText = "select customerId from customerTable where customerEmail = @Email";
                    cmd3.Parameters.AddWithValue("@Email", details.Email);
                    CustomerId = (int)cmd3.ExecuteScalar();
                    con.Close();    


                    purchase = true;
                }
                else
                {
                    Console.WriteLine("Thank you for visiting");
                    Console.WriteLine("Enter email to subscribe for more updates");
                    CustomerDetails details = new CustomerDetails();

                    Console.WriteLine("Enter FullName");
                    details.Name = Console.ReadLine();

                    Console.WriteLine("Enter Email");
                    details.Email = Console.ReadLine();

                    Console.WriteLine("Enter Mobile");
                    details.Mobile = Convert.ToInt64(Console.ReadLine());

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    con.Open();
                    cmd2.CommandText = "Insert into customerTable values (@CustName, @CustEmail, @CustMobile)";
                    cmd2.Parameters.AddWithValue("@CustName", details.Name);
                    cmd2.Parameters.AddWithValue("@CustEmail", details.Email);
                    cmd2.Parameters.AddWithValue("@CustMobile", details.Mobile);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
            else
            {
                Console.WriteLine("Medicine {0} not available in stock", medName);
                //place order function can be inserted here.
                Console.WriteLine(PlaceOrder.Order(medName));
            }


            if (purchase)
            {
                int batchNum, quantity;
                double price;
                SellingOption.Sell(medName, out batchNum, out quantity, out price);
             
                //update order Table
                SellMedicine.orderTableEdit(batchNum, CustomerId, quantity, price);
                
            }


            // when we search for a medicine first it will be searched from this expired medicine list and then in stock so we can clear our stock
            // of expired medicine first.

        }
        public static void orderTableEdit(int batchNum, int CustomerId, int quantity, double price)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string orderDate = dateTime.ToString("d");

            string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";
            SqlConnection con = new SqlConnection(credintialString);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            con.Open();
            cmd3.CommandText = "insert into orderTable values(@OrderId, @ProductId, @CustomerId, @Quantity, @DateOfOrder, @Price)";
            cmd3.Parameters.AddWithValue("@OrderId", batchNum);
            cmd3.Parameters.AddWithValue("@ProductId", ProductId);
            cmd3.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd3.Parameters.AddWithValue("@Quantity", quantity);
            cmd3.Parameters.AddWithValue("@DateOfOrder", orderDate);
            cmd3.Parameters.AddWithValue("@Price", price);
            cmd3.ExecuteNonQuery();
            con.Close();

        }
    }
}
