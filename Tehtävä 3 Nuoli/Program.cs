namespace Tehtävä_3_Nuoli
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa nuolikauppaan.");
            Console.WriteLine("Haluatko:");
            Console.WriteLine("1. Teettää nuolen tilaustyönä?");
            Console.WriteLine("2. Ostaa valmiin nuolen?");
            Console.Write("Valinta: ");
            Nuoli? Ostos=null;
            int valinta = int.Parse(Console.ReadLine());
            if (valinta == 2)
            {
                Console.WriteLine("Valitse valmis Nuoli");
                Console.WriteLine("1. Eliittinuoli");
                Console.WriteLine("2. Aloittelijanuoli");
                Console.WriteLine("3. Perusnuoli");
                Console.Write("Valinta: ");
                int ValmisValinta = int.Parse(Console.ReadLine());

                switch (ValmisValinta) 
                {
                    case 1:Ostos = Nuoli.LuoEliittiNuoli(); break;
                    case 2:Ostos = Nuoli.LuoAloittelijaNuoli();break;
                    case 3:Ostos = Nuoli.LuoPerusNuoli() ;break;
                }
                Console.WriteLine($"Nuolen hinta on {Ostos.PalautaHinta():0.00} kultarahaa");
            }


            else
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

            //Staattiset Metodit
            public static Nuoli LuoEliittiNuoli()
            {
                return new Nuoli(Kärki.timantti,Perä.kotkansulka,100);
            }
            public static Nuoli LuoAloittelijaNuoli()
            {
                return new Nuoli(Kärki.puu, Perä.kanansulka, 70);
            }
            public static Nuoli LuoPerusNuoli()
            {
                return new Nuoli(Kärki.teräs, Perä.kanansulka, 85);
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
