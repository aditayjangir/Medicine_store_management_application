using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingModule
{
    public class SellingOption
    {
        public static void Sell(string medcineName, int rate)
        {
            int quantity = 1;
            Console.WriteLine("Quantity of Medicine required");
            Console.WriteLine("Set Quantity Yes or No");
            string request = Console.ReadLine().ToUpper();
            if (request == "YES")
            {
                quantity = Convert.ToInt32(Console.ReadLine());
            }

            // rate will also be taken from parameter
            float totalAmount = rate * quantity;
            Console.WriteLine("For {0}, Money to be collected = {1}", medcineName, totalAmount);
            // quantity of the medicine will be deducted from the stock

        }
    }
}
