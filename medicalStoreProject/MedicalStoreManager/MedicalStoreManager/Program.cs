// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using MedicalStoreManager;
string drug = File.ReadAllText(@"C:\Users\jangi\OneDrive\Desktop\medical store project\medicalStoreProject\MedicalStoreManager\MedicalStoreManager\medicineName.json");
MedicineName? drugNames = JsonSerializer.Deserialize<MedicineName>(drug);
Console.WriteLine("Search Medicine here...");
String medName = Console.ReadLine();
int flag = 0;
foreach(string med in drugNames.drugs)
{
    if (med == medName)
    {
        Console.WriteLine("Medicine is in box 15-A, total 15 in stock");
        flag = 1;
        break;
    }
}
if(flag != 1)
{
    Console.WriteLine("{0} not in stock", medName);
}