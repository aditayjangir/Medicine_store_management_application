// See https://aka.ms/new-console-template for more information
using SellingModule;
using StockUpdateModule;

bool shopOpeningStatus = true; 
while (shopOpeningStatus)
{
    Console.WriteLine("For Updating Stock Press 1");
    Console.WriteLine("For Selling Medicine Press 2");
    Console.WriteLine("For Returning medicine Press 3");
    Console.WriteLine("For Shop Closing press 4");

    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            UpdatingStock.updateStock();
            Console.WriteLine("Stock Updated Successfully");
            break;
        case 2:
            SellMedicine.SellMedicineFunction();
            Console.WriteLine("Medicine Sold Successfully");
            break;
        case 3:
            ReturnMedicine.Return();
            Console.WriteLine("Medicine Returned Successfully");
            break;
        case 4:
            shopOpeningStatus = false;
            break;
        default:
            Console.WriteLine("entered wrong choice, Choose again");
            continue;
    }
}


