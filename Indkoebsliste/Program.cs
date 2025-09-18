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

    if (input.ToLower() == "vareliste" || input.ToLower() == "listvarer" || input.ToLower() == "lv" ||  input.ToLower() == "vl")
    {
        ListVarer();
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
    
    if (input == "tilføj vare")
    {
        AddNewVarer ();
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
        string[] defaultVarer = new string[]
        {
            "0,Hamburger,40", 
            "1,Nutella,72", 
            "2,brød,7",
        };
        File.WriteAllLines(vareFilNavn, defaultVarer);
    }                                                      
    string[] importTekst = File.ReadAllLines(vareFilNavn); 
    Vare[] produktListeTemp = new Vare[importTekst.Length];    
    int i = 0;                                             
                                                           
    foreach (string line in importTekst)                   
    {                                                      
        Console.WriteLine(line);                           
        string[] opdelt = line.Split(',');                 
        produktListeTemp[i] = new Vare();                      
        produktListeTemp[i].id  = Convert.ToInt32(opdelt[0]);  
        produktListeTemp[i].navn  = opdelt[1];                 
        produktListeTemp[i].pris = Convert.ToDouble(opdelt[2]);
        Console.WriteLine("Taget fra VareArray:");         
        Console.WriteLine(produktListeTemp[i].navn + " " + produktListeTemp[i].pris + " " + produktListeTemp[i].id);                
                                                           
        i++;                                               
    }
    return produktListeTemp;
} 

void AddNewVarer()
{
    Console.WriteLine("tilføj varer til lageret");
    Console.WriteLine("for at tilføje nye varer venligst indtast varens:");
    Console.WriteLine("id, navn, pris");
    while (true)
    {
        Console.WriteLine("For at afslutte skriv slut: tryk Enter for at fortsætte");
       
        string internalinput = Console.ReadLine();
        if (internalinput == "exit" || internalinput == "end" || internalinput == "slut" || internalinput == "færdig")
        {
            Console.WriteLine("du stopper nu tilføjelser af varer til lager");
            break;
        }
        Console.Clear();
        Console.WriteLine("Indtast id:");
        string id = Console.ReadLine();


        Console.WriteLine("Indtast Navn:");
        string navn = Console.ReadLine();

        Console.WriteLine("Indtast Pris:");
        string pris = Console.ReadLine();


        string[] vare = { $"{id},{navn},{pris}"};

        Console.WriteLine(vare);

        File.WriteAllLines(vareFilNavn, vare);

        Console.WriteLine("varen er nu gemt i lager");
    }
}

public class Vare()
{
    public double pris;
    public string navn;
    public int id;
}