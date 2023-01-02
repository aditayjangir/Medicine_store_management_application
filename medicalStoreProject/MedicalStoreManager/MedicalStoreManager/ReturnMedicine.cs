using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnMedicineModule
{
    internal class ReturnMedicine
    {
        public static void Return(string returnedMedicineName, int rate)
        {
            //we will check if the medicine is expired or not with its batch no.
            //we will check if there is any medicine missing from the deck of medicine and adjust the amount to return according to that
            int amount = 0;
            Console.WriteLine("{0} returned", returnedMedicineName);
            Console.WriteLine("Give customer amount {0}Rs ", amount);
            //then we will update the stock.
        }
    }
}
