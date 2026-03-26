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
            static RobottiKäsky? LuoKäsky(string? syöte)
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
    public abstract class RobottiKäsky
    {
        public abstract void Suorita(Robotti robotti);
    }
    public class Robotti
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool OnKäynnissä { get; set; }
        public RobottiKäsky?[] Käskyt { get; } = new RobottiKäsky?[3];

        public void Suorita()
        {
            foreach (RobottiKäsky? käsky in Käskyt)
            {
                käsky?.Suorita(this);
                Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
            }
        }
        public class Käynnistä : RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = true;
            }
        }
        public class Sammuta: RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = false;
            }
        }
        public class YlösKäsky: RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.Y += 1;
                }
            }
        }
        public class AlasKäsky : RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.Y -= 1;
                }
            }
        }
        public class VasenKäsky : RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.X -= 1;
                }
            }
        }
        public class OikeaKäsky : RobottiKäsky
        {
            public override void Suorita(Robotti robotti)
            {
                if (robotti.OnKäynnissä)
                {
                    robotti.X += 1;
                }
            }
        }
    }
}
