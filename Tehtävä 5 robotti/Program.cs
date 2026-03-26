using static Tehtävä_5_robotti.Robotti;

namespace Tehtävä_5_robotti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vaihtoehdot: oikea, vasen, alas, ylös, sammuta, käynnistä");
            Robotti robotti = new Robotti();
            for (int i = 0; i < 3; i++)
            {
                
                Console.WriteLine("Anna Käsky");
                string syöte= Console.ReadLine();
                robotti.Käskyt[i] = LuoKäsky(syöte);
            }
            robotti.Suorita();
            static IRobottiKäsky? LuoKäsky(string? syöte)
            {
                return syöte?.ToLower() switch
                {
                    "käynnistä" => new Käynnistä(),
                    "sammuta" => new Sammuta(),
                    "ylös" => new YlösKäsky(),
                    "alas" => new AlasKäsky(),
                    "vasen" => new VasenKäsky(),
                    "oikea" => new OikeaKäsky(),
                    _ => null
                };
            }
        }
    }
    public interface IRobottiKäsky
    {
        public abstract void Suorita(Robotti robotti);
    }
    public class Robotti
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool OnKäynnissä { get; set; }
        public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3];

        public void Suorita()
        {
            foreach (IRobottiKäsky? käsky in Käskyt)
            {
                käsky?.Suorita(this);
                Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
            }
        }
        public class Käynnistä : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = true;
            }
        }
        public class Sammuta: IRobottiKäsky
        {
            public  void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = false;
            }
        }
        public class YlösKäsky: IRobottiKäsky
        {
            public  void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.Y += 1;
                }
            }
        }
        public class AlasKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.Y -= 1;
                }
            }
        }
        public class VasenKäsky : IRobottiKäsky
        {
            public  void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.X -= 1;
                }
            }
        }
        public class OikeaKäsky : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.X += 1;
                }
            }
        }
    }
}
