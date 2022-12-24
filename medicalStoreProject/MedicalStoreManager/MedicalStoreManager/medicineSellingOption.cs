using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellOption
{
    public class medicineSellingOption
    {
        public static void sell(string medcineName)
        {
            Console.WriteLine("Quantity of Medicine required");
            int quantity = int.Parse(Console.ReadLine());
            int rate = 0;
            // rate will also be taken from parameter
            Console.WriteLine("{0}, Money to be collected = {1}", medcineName, rate * quantity);
            // quantity of the medicine will be deducted from the stock
        }
    }
}
