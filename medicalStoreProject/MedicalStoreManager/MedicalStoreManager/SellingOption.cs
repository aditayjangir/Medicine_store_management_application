using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sellingModule
{
    public class SellingOption
    {
        public static void sell(string medcineName, int rate)
        {
            int quantity = 1;
            Console.WriteLine("Quantity of Medicine required");
            Console.WriteLine("Set Quantity Yes or No");
            string Request = Console.ReadLine().ToUpper();
            if (Request == "YES")
            {
                quantity = Convert.ToInt32(Console.ReadLine());
            }

            // rate will also be taken from parameter
            float TotalAmount = rate * quantity;
            Console.WriteLine("For {0}, Money to be collected = {1}", medcineName, TotalAmount);
            // quantity of the medicine will be deducted from the stock

        }
    }
}
