namespace Tehtävä_2_Ruoka_annos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa ravintolaan");
            //uusi olio
            Ateria tilaus = new Ateria();
            string[]aineet=Enum.GetNames< Pääraaka_Aine > ();

            tilaus.Pääraaka_Aine = KysyPaaraakaAine();
            tilaus.Lisuke=KysyLisuke();
            tilaus.Kastike=KysyKastike();

            Console.WriteLine("Tilauksesi on:");
            tilaus.Tulosta();
        }
        static Pääraaka_Aine KysyPaaraakaAine()
        {
            while (true) 
            {
                Console.WriteLine("Valitse Pääraakaaine: Nautaa, Kanaa ja Kasviksia");
                string syote = Console.ReadLine();
                if (Enum.TryParse(syote, true, out Pääraaka_Aine tulos))
                    return tulos;
                Console.WriteLine("Valitettavasti meillä ei ole");
            }
        }
        static Lisuke KysyLisuke()
        {
            while (true) 
            { 
                Console.WriteLine("Valitse Lisuke: Perunaa, Riisiä ja Pastaa ");
                string syote = Console.ReadLine();
                if (Enum.TryParse(syote, true, out Lisuke tulos))
                    return tulos;
                Console.WriteLine("Valitettavasti meillä ei ole");
            }
        }
        static Kastike KysyKastike()
        {
            while (true) 
            {
                Console.WriteLine("Valitse Kastike: curry, hapanimelä, pippuri ja chili");
                string syote = Console.ReadLine();
                if (Enum.TryParse(syote, true, out Kastike tulos))
                    return tulos;
                Console.WriteLine("Valitettavasti meillä ei ole ota jotain muuta");
            }
        }
       class Ateria
        {
            public Pääraaka_Aine Pääraaka_Aine { get; set; }
            public Lisuke Lisuke { get; set; }
            public Kastike Kastike { get; set; }
            public Ateria() { }
            public Ateria(Pääraaka_Aine paaRaakaAine, Lisuke lisuke, Kastike kastike)
            {
                Pääraaka_Aine = paaRaakaAine;
                Lisuke = lisuke;
                Kastike = kastike;
            }

            public void Tulosta()
            {
                Console.WriteLine($"{Pääraaka_Aine} ja {Lisuke} {Kastike}-kastikkeella");
            }
        }
        enum Pääraaka_Aine
        {
            nautaa,
            kanaa,
            kasviksia
        }
        enum Lisuke
        {
            perunaa,
            riisiä,
            pastaa
        }
        enum Kastike
        {
            curry,
            hapanimelä,
            pippuri,
            chili
        }
    }
}
