// See https://aka.ms/new-console-template for more information
string vareFilNavn = "vareFil.txt";


Vare[] produktListe = new Vare[10];
produktListe[0] = new Vare();
produktListe[1] = new Vare();
produktListe[2] = new Vare();
produktListe[3] = new Vare();
produktListe[4] = new Vare();
produktListe[5] = new Vare();
produktListe[6] = new Vare();
produktListe[7] = new Vare();
produktListe[8] = new Vare();
produktListe[9] = new Vare();

produktListe[0].id = 0;
produktListe[1].id = 1;
produktListe[2].id = 2;
produktListe[3].id = 3;
produktListe[4].id = 4;
produktListe[5].id = 5;
produktListe[6].id = 6;
produktListe[7].id = 7;
produktListe[8].id = 8;
produktListe[9].id = 9;

produktListe[0].navn = "Burger";
produktListe[1].navn = "Frikadelle";
produktListe[2].navn = "Brød";
produktListe[3].navn = "Tandpasta";
produktListe[4].navn = "Toiletpapir";
produktListe[5].navn = "Vingummi";
produktListe[6].navn = "Smør";
produktListe[7].navn = "Lim";
produktListe[8].navn = "Hakkekød";
produktListe[9].navn = "Grød";

produktListe[0].pris = 20;
produktListe[1].pris = 30;
produktListe[2].pris = 40;
produktListe[3].pris = 50;
produktListe[4].pris = 60;
produktListe[5].pris = 70;
produktListe[6].pris = 80;
produktListe[7].pris = 90;
produktListe[8].pris = 100;
produktListe[9].pris = 200;

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

public class Vare()
{
    public double pris;
    public string navn;
    public int id;
}


