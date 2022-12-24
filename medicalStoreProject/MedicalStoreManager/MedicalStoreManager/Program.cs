// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using medicineNameList;
using SellOption;
string drug = File.ReadAllText(@"C:\Users\jangi\OneDrive\Desktop\medical store project\medicalStoreProject\MedicalStoreManager\MedicalStoreManager\medicineName.json");
MedicineName? drugNames = JsonSerializer.Deserialize<MedicineName>(drug);
Console.WriteLine("Search Medicine here...");
String medName = Console.ReadLine();
if (drugNames.drugs.Contains(medName))
{
    Console.WriteLine("Medicine available");
    // find where the medicine is at and selling option.
    medicineSellingOption.sell(medName);
}
else
{
    Console.WriteLine("Medicine {0} not available in stock", medName);
    //place order function can be inserted here.
}