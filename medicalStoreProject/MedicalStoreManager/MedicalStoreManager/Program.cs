// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using MedicineNameList;
using PlaceOrderModule;
using SellingModule;
using ReturnMedicineModule;
using ManageNearExpiredMedicineModule; 

string drugData = File.ReadAllText(@"../../../MedicineDetails.json");
MedicineList? drugList = JsonSerializer.Deserialize<MedicineList>(drugData);
Console.WriteLine(drugList.drugs);
Console.WriteLine("Search Medicine here...");
String medName = Console.ReadLine();
int rate = Convert.ToInt32(drugList.rate);

if (drugList.drugs.Contains(medName))
{
    Console.WriteLine("Medicine available");
    //rate will be read from data set
    
    // find where the medicine is at and selling option.
    Console.WriteLine("Want to place order Yes or No");
    string request1 = Console.ReadLine().ToUpper();
    if (request1 == "YES")
    {
        CustomerDetails details = new CustomerDetails();

        Console.WriteLine("Enter FullName");
        details.Name = Console.ReadLine();

        Console.WriteLine("Enter Email");
        details.Email = Console.ReadLine();

        Console.WriteLine("Enter Mobile");
        details.Mobile = Console.ReadLine();

        SellingOption.Sell(medName, rate);
        // Add payment page for online payment
    }
    else
    {
        Console.WriteLine("Thank you for visiting");
        Console.WriteLine("Enter email to subscribe for more updates");
        CustomerDetails details = new CustomerDetails();
        details.Email = Console.ReadLine();
    }
}
else
{
    Console.WriteLine("Medicine {0} not available in stock", medName);
    //place order function can be inserted here.
    Console.WriteLine(PlaceOrder.Order(medName));
}

//function to manage expired medicine
ManageNearExpiredMedicine.NearExpiredMedicineList(drugList);
    // when we search for a medicine first it will be searched from this expired medicine list and then in stock so we can clear our stock
    // of expired medicine fast. 

//function to manage damaged medicine

//function to manage returned medicine
Console.WriteLine("Do you want to return any medicine Yes or No");
string request2 = Console.ReadLine().ToUpper();
if (request2 == "Yes")
{
    Console.WriteLine("Enter medicine name");
    String returnedMedicineName = Console.ReadLine();
    //we can put an if condition stating is medicine wrapper is opened or not
    if (drugList.drugs.Contains(returnedMedicineName))
    {
        ReturnMedicine.Return(returnedMedicineName, rate);
    }

}