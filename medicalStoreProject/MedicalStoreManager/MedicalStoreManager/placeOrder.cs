using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace placeOrderModule
{
    // place order from government inventory
    public class placeOrder
    {
        public static string Order(string medicineName)
        {
            Console.WriteLine("Choose option to place order");
            Console.WriteLine("1. Contact agent");
            Console.WriteLine("2. Online portal");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    {
                        return "Order places successfully from agent";
                    }
                case 2:
                    {
                        return "Order places successfully from online portal";
                    }
                default:
                    {
                        return "Order Unsuccessful";
                    }
            }
        }
    }
}
