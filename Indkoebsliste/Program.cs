// See https://aka.ms/new-console-template for more information

using System.Globalization;

string vareFilNavn = "vareFil.txt";
Vare[] produktListe = ReadFromFile();

Console.WriteLine("Hvad vil du købe?");
List<Vare> indkøbsVogn = new List<Vare>();
while (true)
{
    string input =  Console.ReadLine();
    if (input == "end" || input == "slut")
    {
        break;
    }

    if (input.ToLower() == "vareliste" || input.ToLower() == "listvarer" || input.ToLower() == "lv")
    {
        ListVarer();
        input = Console.ReadLine();
    }

    foreach (var vare in produktListe)
    {
        if (input == vare.id.ToString())
        {
            indkøbsVogn.Add(produktListe[vare.id]);
        }
    }
    Console.Clear();
    Console.WriteLine("Varene i indkøbsvognen");
    foreach (var vare in indkøbsVogn)
    {
        Console.WriteLine(vare.navn);
    }
    
}

Console.Clear();
Console.WriteLine("Tak for at handle hos SuperJakup");
double totalPris = 0;
foreach (var vare in indkøbsVogn)
{
    Console.WriteLine(vare.navn + " " + vare.pris + " kr");
    totalPris += vare.pris;
}
Console.WriteLine("Total: " + totalPris);
void ListVarer()
{
    foreach (var vare in produktListe)
    {
        Console.WriteLine(vare.id + ". " + vare.navn + " Pris: " +  vare.pris +"kr");
    }
}

Vare[] ReadFromFile()                                        
{                                                          
    if (!File.Exists(vareFilNavn))                         
    {                                                      
        File.Create(vareFilNavn);                          
    }                                                      
    string[] importTekst = File.ReadAllLines(vareFilNavn); 
    Vare[] produktListe = new Vare[importTekst.Length];    
    int i = 0;                                             
                                                           
    foreach (string line in importTekst)                   
    {                                                      
        Console.WriteLine(line);                           
        string[] opdelt = line.Split(',');                 
        produktListe[i] = new Vare();                      
        produktListe[i].navn  = opdelt[0];                 
        produktListe[i].pris = Convert.ToDouble(opdelt[1]);
        produktListe[i].id  = Convert.ToInt32(opdelt[2]);  
        Console.WriteLine("Taget fra VareArray:");         
        Console.WriteLine(produktListe[i]);                
                                                           
        i++;                                               
    }
    return produktListe;
}                                                          

public class Vare()
{
    public double pris;
    public string navn;
    public int id;
}



void AddNewVarer()
{
    Console.WriteLine("tilføj varer til lageret");
    Console.WriteLine("for at tilføje nye varer venligst indtast varens:");
    Console.WriteLine("id, navn, pris");
    while (true)
    {

        Console.WriteLine("Indtast id:");
        string id = Console.ReadLine();

        if (id == "exit" || id == "end" || id == "slut" || id == "færdig")
        {
            Console.WriteLine("du stopper nu tilføjelser af varer til lager");
            break;
        }

        Console.WriteLine("Indtast Navn:");
        string navn = Console.ReadLine();

        Console.WriteLine("Indtast Pris:");
        string pris = Console.ReadLine();

        string vare = $"{id},{navn},{pris}";

        Console.WriteLine(vare);

        File.AppendAllLines("vareFil.txt", vare);

        Console.WriteLine("varen er nu gemt i lager");
    }
}

