namespace Door
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OvenTila oven_tila = OvenTila.Lukossa;
            //tutki vastaus
            //katso mikä onven tila
            //Jos toiminto on järkevä, muuta oven tilaa
            //Kysy uudestaan
            while (true)
            {
                Console.WriteLine($"Ovi on {oven_tila.ToString().ToLower()}. Mitä haluat tehdä?");
                string[] toiminnot = Enum.GetNames<OvenToiminto>();
                for (int t = 0; t < toiminnot.Length; t += 1)
                {
                    Console.WriteLine(toiminnot[t]);
                }
                Console.Write("Valinta:");
                string vastaus = Console.ReadLine();
                OvenToiminto toiminto;
                if (!Enum.TryParse(vastaus, true, out toiminto))
                {
                    Console.WriteLine("Virheellinen toiminto.");
                    continue;
                }
                bool onnistuiko = false;
                switch (toiminto)
                {
                    case OvenToiminto.AvaaLukko:
                        if (oven_tila == OvenTila.Lukossa)
                        {
                            oven_tila= OvenTila.Kiinni;
                            onnistuiko = true;
                        }
                        break;
                    case OvenToiminto.Avaa:
                        if (oven_tila == OvenTila.Kiinni)
                        {
                            oven_tila = OvenTila.Auki;
                            onnistuiko = true;
                        }
                        break;
                    case OvenToiminto.Sulje:
                        if (oven_tila == OvenTila.Auki) 
                        {
                            oven_tila=OvenTila.Kiinni;
                            onnistuiko = true;
                        }
                        break;
                    case OvenToiminto.Lukitse:
                        if (oven_tila == OvenTila.Kiinni)
                        {
                            oven_tila = OvenTila.Lukossa;
                            onnistuiko=true;
                        }
                        break;
                }
                if (onnistuiko)
                {
                    Console.WriteLine("Toiminto onnistui.");
                }
                else
                {
                    Console.WriteLine("Toiminto ei ole mahdollinen tässä tilassa.");
                }

            }
        }
        enum OvenTila
        {
            Auki,
            Kiinni,
            Lukossa
        }
        enum OvenToiminto
        {
            Sulje,
            Lukitse,
            Avaa,
            AvaaLukko
        }
    }
}
