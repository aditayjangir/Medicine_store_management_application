// See https://aka.ms/new-console-template for more information
String[] MedicineName = new string[] { "Acetaminophen", "Adderall", "Amitriptyline", "Amlodipine", "Amoxicillin", "Ativan", "Atorvastatin", "Azithromycin", "Benzonatate", "Brilinta", "Bunavail", "Buprenorphine", "Cephalexin", "Ciprofloxacin", "Citalopram", "Clindamycin", "Clonazepam", "Cyclobenzaprine", "Cymbalta", "Doxycycline", "Dupixent", "Entresto", "Entyvio", "Farxiga", "Fentanyl", "Fentanyl Patch", "Gabapentin", "Gilenya", "Humira", "Hydrochlorothiazide", "Hydroxychloroquine", "Ibuprofen", "Imbruvica", "Invokana", "Januvia", "Jardiance", "Kevzara", "Lexapro", "Lisinopril", "Lofexidine", "Loratadine", "Lyrica", "Melatonin", "Meloxicam", "Metformin", "Methadone", "Methotrexate", "Metoprolol", "Naloxone", "Naltrexone", "Naproxen", "Omeprazole", "Onpattro", "Otezla", "Ozempic", "Pantoprazole", "Prednisone", "Probuphine", "Rybelsus", "secukinumab", "Sublocade", "Tramadol", "Trazodone", "Viagra", "Wellbutrin", "Xanax", "Zubsolv", };
Console.WriteLine("Search Medicine here...");
String medName = Console.ReadLine();
int flag = 0;
foreach(string med in MedicineName)
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