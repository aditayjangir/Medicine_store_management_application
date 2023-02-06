// See https://aka.ms/new-console-template for more information
using SellingModule;
using StockUpdateModule;

while (true)
{
    Console.WriteLine("For Updating Stock press 1");
    Console.WriteLine("For selling medicine press 2");
    Console.WriteLine("For Returning medicine press 3");

    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            //UpdateStock();
            break;
        case 2:
            SellMedicine.SellMedicineFunction();
            break;
        case 3:
            ReturnMedicine.Return();
            break;
        default:
            Console.WriteLine("entered wrong choice, Choose again");
            continue;
    }
}


