﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceOrderModule
{
    // place order from government inventory
    public class PlaceOrder
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
                        return "Order of "+ medicineName +" has been places successfully from agent";
                    }
                case 2:
                    {
                        return "Order of " + medicineName + " has been places successfully from online portal";
                    }
                default:
                    {
                        return "Order of " + medicineName + " is Unsuccessfull";
                    }
            }
        }
    }
}
