using KajakKolcsonzo;

List<Kolcsonzes> adatok=new List<Kolcsonzes>();
Console.WriteLine("Rögzített hajókölcsönzések:");
foreach(string sor in File.ReadAllLines("kolcsonzesek.txt"))
{
    adatok.Add(new Kolcsonzes(sor)) ;
}
foreach(Kolcsonzes aktualis in adatok)
{
    Console.WriteLine(aktualis);
}
Console.WriteLine("\nÖsszesített statisztika:");
int teljes = adatok.Sum(x => x.FizetendoOsszeg());
Console.WriteLine($"Kölcsönző teljes bevétele: {teljes} Ft");
int orasz = adatok.Sum(x => x.BereltOrak);
Console.WriteLine($"Összes bérelt óraszám: {orasz} óra");
double atlag = adatok.Average(x => x.BereltOrak);
Console.WriteLine( $"Átlagos kölcsönzési idő: {atlag:F0} óra");
Kolcsonzes leg = adatok.MaxBy(x=>x.FizetendoOsszeg());
Console.WriteLine($"Legtöbbet fizető bérlő: {leg.BerloNev} ({leg.FizetendoOsszeg()} Ft)");
int szamol = adatok.Count(x => x.HajoTipus == "KENU" && x.KesesPerc == 0);
Console.WriteLine($"Késés nélkül visszahozott KENU kölcsönzések száma: {szamol} db");

Console.WriteLine("\nKésedelmi pótdíjat fizető bérlők:");
foreach(Kolcsonzes atmegy in adatok)
{
    if (atmegy.KesesPerc > 15)
    {
        Console.WriteLine($"{atmegy.BerloNev} ({atmegy.KesesPerc} perc)");
    }
}