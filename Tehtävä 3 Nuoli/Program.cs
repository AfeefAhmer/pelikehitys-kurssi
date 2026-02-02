namespace Tehtävä_3_Nuoli
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valitse kärki (0 = puu, 1 = teräs, 2 = timantti)");
            Kärki kärki = (Kärki)int.Parse(Console.ReadLine());

            Console.WriteLine("Valitse perä (0 = lehti, 1 = kanansulka, 2 = kotkansulka)");
            Perä perä = (Perä)int.Parse(Console.ReadLine());

            Console.WriteLine("Valitse VarrenPituus (60 - 100 cm");
            int pituus = int.Parse(Console.ReadLine());

            Nuoli nuoli = new Nuoli(kärki, perä, pituus);

            Console.WriteLine($"Nuolen hinta on {nuoli.PalautaHinta():0.00} kultarahaa");
        }
        class Nuoli
        {
            public Kärki Kärki{get;private set;}
            public Perä Perä { get; private set; }
            private int varrenPituus;
            public int VarrenPituus
            {
                get { return varrenPituus; }
                private set
                {
                    if (value >= 60 && value <= 100)
                        varrenPituus = value;
                }
            }
            public Nuoli(Kärki kärki, Perä perä, int varrenPituus)
            {
                Kärki = kärki;
                Perä = perä;
                VarrenPituus = varrenPituus;
            }
            public double PalautaHinta()
            {
                double hinta = 0;
                switch (Kärki)
                {
                    case Kärki.puu: hinta += 3;break;
                    case Kärki.teräs: hinta += 5;break;
                    case Kärki.timantti: hinta += 50;break;
                }
                switch (Perä)
                {
                    case Perä.lehti: hinta += 0;break;
                    case Perä.kanansulka: hinta += 1;break;
                    case Perä.kotkansulka: hinta += 5;break;
                }
                hinta += VarrenPituus * 0.05;

                return hinta;
            }
        }
        enum Kärki
        {
            puu,
            teräs,
            timantti
        }
        enum Perä
        {
            lehti,
            kanansulka,
            kotkansulka
        }
    }
}
