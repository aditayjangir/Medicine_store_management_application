// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using medicineNameList;
using placeOrderModule;
using sellingModule;

string drugData = File.ReadAllText(@"C:\Users\jangi\OneDrive\Desktop\medical store project\medicalStoreProject\MedicalStoreManager\MedicalStoreManager\medicineDetails.json");
MedicineList? drugList = JsonSerializer.Deserialize<MedicineList>(drugData);
Console.WriteLine("Search Medicine here...");
String medName = Console.ReadLine();

if (drugList.drugs.Contains(medName))
{
    Console.WriteLine("Medicine available");
    //rate will be read from data set
    int Rate = 120;
    // find where the medicine is at and selling option.
    Console.WriteLine("Want to place order Yes or No");
    string Request = Console.ReadLine().ToUpper();
    if (Request == "YES")
    {
        customerDetails details = new customerDetails();

        Console.WriteLine("Enter FullName");
        details.Name = Console.ReadLine();

        Console.WriteLine("Enter Email");
        details.Email = Console.ReadLine();

        Console.WriteLine("Enter Mobile");
        details.Mobile = Console.ReadLine();

        SellingOption.sell(medName, Convert.ToInt32(drugList.rate));
        // Add payment page for online payment
    }
    else
    {
        Console.WriteLine("Thank you for visiting");
        Console.WriteLine("Enter email to subscribe for more updates");
        customerDetails details = new customerDetails();
        details.Email = Console.ReadLine();
    }
}
else
{
    Console.WriteLine("Medicine {0} not available in stock", medName);
    //place order function can be inserted here.
    Console.WriteLine(placeOrder.Order(medName));
}
//function to manage expired medicine

//function to manage damaged medicine

//function to manage returned medicine