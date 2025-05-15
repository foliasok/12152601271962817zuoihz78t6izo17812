using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetWPF
{
    public class Lovesz
    {
        public string Nev { get; private set; }
        public int ElsoLoves { get; private set; }
        public int MasodikLoves { get; private set; }
        public int HarmadikLoves { get; private set; }
        public int NegyedikLoves { get; private set; }

        public Lovesz(string sor)
        {
            var data = sor.Split(';');
            Nev = data[0];
            ElsoLoves = int.Parse(data[1]);
            MasodikLoves = int.Parse(data[2]);
            HarmadikLoves = int.Parse(data[3]);
            NegyedikLoves = int.Parse(data[4]);
        }
    }
}
