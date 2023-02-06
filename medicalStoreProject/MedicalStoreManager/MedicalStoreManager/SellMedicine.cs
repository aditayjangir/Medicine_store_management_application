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
        public static void SellMedicineFunction()
        {


            Console.WriteLine("Search Medicine here...");
            String? medName = Console.ReadLine();
            SqlDataReader DbResult = null;
            bool purchase = false;

            string credintialString = "data source = .; database = MedicalStoreDB; integrated security = SSPI";
            SqlConnection con = new SqlConnection(credintialString);
            SqlCommand cmd1 = new SqlCommand("select * from productTable where productName = @ProductName", con);
            cmd1.Parameters.AddWithValue("@ProductName", medName);
            con.Open();
            DbResult = cmd1.ExecuteReader();

            if (DbResult.Read())
            {
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
                    cmd2.CommandText = "Insert into customerTable values (1006, @CustName, @CustEmail, @CustMobile)";
                    cmd2.Parameters.AddWithValue("@CustName", details.Name);
                    cmd2.Parameters.AddWithValue("@CustEmail", details.Email);
                    cmd2.Parameters.AddWithValue("@CustMobile", details.Mobile);
                    int TotalRowsAffected = cmd2.ExecuteNonQuery();
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
                    int TotalRowsAffected = cmd2.ExecuteNonQuery();
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
                SellingOption.Sell(medName);
            }



           // function to manage expired medicine
           //  open sql connection inside the method don't pass it as an arguments.
           // ManageNearExpiredMedicine.NearExpiredMedicineList();
           // when we search for a medicine first it will be searched from this expired medicine list and then in stock so we can clear our stock

           // of expired medicine first.

            

        }
    }
}
