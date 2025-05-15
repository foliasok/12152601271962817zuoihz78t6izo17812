using System.IO;

namespace CelloveszetCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("lovesek.csv"); // a fájl beolvasása
            List<Lovesz> loveszek = new List<Lovesz>(); // lista a lövészek adatainak tárolására

            // a lövészek adatainak beolvasása
            for (int i = 0; i < fajl.Length; i++)
            {
                loveszek.Add(new Lovesz(fajl[i]));
            }
            foreach (var l in loveszek)
            {
                Console.WriteLine($"{l.Nev} {Legnagyobb(l.ElsoLoves, l.MasodikLoves, l.HarmadikLoves, l.NegyedikLoves)}");
            }

            // a legnagyobb találatot lövő kiválasztása
            int legnagyobbPont = 0;
            Lovesz legjobbLovesz = loveszek[0];
            foreach (var l in loveszek)
            {
                if(l.ElsoLoves > legnagyobbPont || l.MasodikLoves > legnagyobbPont || l.HarmadikLoves > legnagyobbPont || l.NegyedikLoves > legnagyobbPont)
                {
                    legnagyobbPont = Legnagyobb(l.ElsoLoves, l.MasodikLoves, l.HarmadikLoves, l.NegyedikLoves);
                    legjobbLovesz = l;
                }
            }
            Console.WriteLine("A legnagyobb találatot lövő eredményei:");
            Console.WriteLine($"{legjobbLovesz.Nev} {legjobbLovesz.ElsoLoves} {legjobbLovesz.MasodikLoves} {legjobbLovesz.HarmadikLoves} {legjobbLovesz.NegyedikLoves}");
           
            // a leggyengébb átlagú találat kiválasztása
            double leggyengebbAtlag = 100;
            Lovesz leggyengebbAtlagLovesz = loveszek[0];
            foreach (var l in loveszek)
            {
                if (Atlag(l.ElsoLoves, l.MasodikLoves, l.HarmadikLoves, l.NegyedikLoves) < leggyengebbAtlag)
                {
                    leggyengebbAtlag = Atlag(l.ElsoLoves, l.MasodikLoves, l.HarmadikLoves, l.NegyedikLoves);
                    leggyengebbAtlagLovesz = l;
                }
            }
            Console.WriteLine("A leggyengébbátlagú találatot lövő eredményei:");
            Console.WriteLine($"{leggyengebbAtlagLovesz.Nev} {leggyengebbAtlag}");
        }
        // a legnagyobb pontot kiválasztó függvény
        public static int Legnagyobb(int elsoloves, int masodikloves, int harmadikloves, int negyedikloves)
        {
            int n = elsoloves;
            if(masodikloves > n)
            {
                n = masodikloves;
            }
            if(harmadikloves > n)
            {
                n = harmadikloves;
            }
            if(negyedikloves > n)
            {
                n = negyedikloves;
            }
            return n;
        }
        // az átlagot kiszámoló függvény
        public static double Atlag(int elsoloves, int masodikloves, int harmadikloves, int negyedikloves)
        {
            return (elsoloves + masodikloves + harmadikloves + negyedikloves) / 4;
        }
    }
}
