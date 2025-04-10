using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto.Models
{
    public class Esemeny
    {
        /*
         1 belépés a főkapun át
         2 kilépés a főkapun át
         3 az ebéd kiadása a menzán
         4 kölcsönzés a könyvtárban
         */


        string tanulokod;
        string ido;
        int tevekenyseg;

        public Esemeny(string sor)
        {
            var mezo = sor.Split(" ");
            Tanulokod = mezo[0];
            Ido = mezo[1];
            Tevekenyseg = int.Parse(mezo[2]);
            

        }

        public string Tanulokod { get => tanulokod; set => tanulokod = value; }
        public string Ido { get => ido; set => ido = value; }
        public int Tevekenyseg { get => tevekenyseg; set => tevekenyseg = value; }

        public int Minute => Convert.ToInt32(ido.Split(":")[1]);
        public int Hour => Convert.ToInt32(ido.Split(":")[0]);

    }
}
