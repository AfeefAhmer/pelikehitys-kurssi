using System.Linq.Expressions;

namespace Tehtävä_4_seikkailureppu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reppu reppu = new Reppu(10, 20, 15);
            while (true)
            {
                reppu.TulostaTiedot();
                Console.WriteLine("Mitä haluat lisätä");
                Console.WriteLine("Nuoli: 1");
                Console.WriteLine("Jousi: 2");
                Console.WriteLine("Köysi: 3");
                Console.WriteLine("Vettä: 4");
                Console.WriteLine("Ruokaa: 5");
                Console.WriteLine("Miekka: 6");
                Console.WriteLine("Lopeta: 0");
                string valinta = Console.ReadLine();
                Tavara tavara = null!;

                switch (valinta) 
                {
                    case "1":
                        tavara = new Nuoli();
                        break;
                    case "2":
                        tavara= new Jousi();
                        break;
                    case "3":
                        tavara = new Koysi();
                        break;
                    case "4":
                        tavara = new Vesi();
                        break;
                    case "5":
                        tavara = new RuokaAnnos();
                        break;
                    case "6":
                        tavara = new Miekka();
                        break;
                    case "0":
                        reppu.TulostaTiedot();
                        return;
                }
                if (tavara != null!) 
                {
                    if (reppu.Lisaa(tavara))
                    {
                        Console.WriteLine("Tavara lisätty!");
                    }
                    else
                    {
                        Console.WriteLine("Tavaran lisäminen ei onnistu");
                    }
                }
            }
        }
    }
    public class Tavara
    {
        public double Paino { get; }
        public double Tilavuus { get; }

        public Tavara(double paino, double tilavuus)
        {
            Paino = paino;
            Tilavuus = tilavuus;
        }
    }

    public class Nuoli : Tavara
    {
        public Nuoli() : base(0.1, 0.05) { }
    }

    public class Jousi : Tavara
    {
        public Jousi() : base(1, 4) { }
    }

    public class Koysi : Tavara
    {
        public Koysi() : base(1, 1.5) { }
    }

    public class Vesi : Tavara
    {
        public Vesi() : base(2, 2) { }
    }

    public class RuokaAnnos : Tavara
    {
        public RuokaAnnos() : base(1, 0.5) { }
    }

    public class Miekka : Tavara
    {
        public Miekka() : base(5, 3) { }
    }


    public class Reppu
    {
        private List<Tavara> tavarat = new List<Tavara>();

        public int MaxMaara { get; }
        public double MaxPaino { get; }
        public double MaxTilavuus { get; }

        public Reppu(int maxMaara, double maxPaino, double maxTilavuus)
        {
            MaxMaara = maxMaara;
            MaxPaino = maxPaino;
            MaxTilavuus = maxTilavuus;
        }

        public int TavaroidenMaara => tavarat.Count;
        public double NykyPaino => tavarat.Sum(t => t.Paino);
        public double NykyTilavuus => tavarat.Sum(t => t.Tilavuus);

        public bool Lisaa(Tavara tavara)
        {
            if (TavaroidenMaara + 1 > MaxMaara)
                return false;

            if (NykyPaino + tavara.Paino > MaxPaino)
                return false;

            if (NykyTilavuus + tavara.Tilavuus > MaxTilavuus)
                return false;

            tavarat.Add(tavara);
            return true;
        }

        public void TulostaTiedot()
        {
            Console.WriteLine("Repussa:");
            Console.WriteLine($"Tavaroita: {TavaroidenMaara}/{MaxMaara}");
            Console.WriteLine($"Paino: {NykyPaino}/{MaxPaino}");
            Console.WriteLine($"Tilavuus: {NykyTilavuus}/{MaxTilavuus}");
            Console.WriteLine();
        }
    }

}
