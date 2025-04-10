using belepteto.Models;
using System;
using System.Linq;



namespace belepteto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EsemenyKezelo esemenyKezelo = new EsemenyKezelo();

            esemenyKezelo.LoadFromData("bedat.txt");


            Console.WriteLine("Extra feladatok Ofotol:");
            Console.Write("Ezek a diákok ebédeltek: ");
            esemenyKezelo.EbedelokKodjai().ForEach(x=>Console.Write(x + "\t "));
            Console.WriteLine();

            int minimumIdoPercben = esemenyKezelo.Esemenyek.Min(x => x.Hour * 60 + x.Minute);
            string minimumIdoNormalisan = $"{(minimumIdoPercben/60).ToString().PadLeft(2, '0')}:{(minimumIdoPercben - minimumIdoPercben / 60 * 60).ToString().PadLeft(2, '0')}";

            int maximumIdoPercben = esemenyKezelo.Esemenyek.Max(x => x.Hour * 60 + x.Minute);
            string maximumIdoNormalisan = $"{(maximumIdoPercben / 60).ToString().PadLeft(2, '0')}:{(maximumIdoPercben - maximumIdoPercben / 60 * 60).ToString().PadLeft(2, '0')}";

            Console.WriteLine("2. feladat");
            Console.WriteLine($"Első tanuló: {minimumIdoNormalisan} \n " +
                $"              Utolsó tanuló: {maximumIdoNormalisan}");

            Console.WriteLine("4. feladat");
            Console.WriteLine($"Ennyi tanuló ebédelt aznap:  {esemenyKezelo.Esemenyek.Count(x=> x.Tevekenyseg == 3)}");

            Console.WriteLine("5. feladat");
            int hanyanKolcsonoztek = esemenyKezelo.Esemenyek.Where(x => x.Tevekenyseg == 4).DistinctBy(x=> x.Tanulokod).Count();
            Console.WriteLine($"Aznap {hanyanKolcsonoztek} tanuló kölcsönzött a könyvtárban");
            if (hanyanKolcsonoztek > esemenyKezelo.Esemenyek.Where(x => x.Tevekenyseg == 3).DistinctBy(x => x.Tanulokod).Count())
            {
                Console.WriteLine("Többen voltak, mint a menzán.");
            }
            else
            {
                Console.WriteLine("Nem voltak többen a menzán.");
            }

            Console.WriteLine("7. feladat");
            Console.Write("Egy tanuló azonosítója= ");
            string bekertDiakKodja = Console.ReadLine();

            int bekertDiak_erkezesePercben = Convert.ToInt32(esemenyKezelo.Esemenyek.Where(x => x.Tevekenyseg == 1 && x.Tanulokod == bekertDiakKodja).Select(x => x.Minute + x.Hour * 60));
            string bekertDiak_erkezeseOraban = $"{(bekertDiak_erkezesePercben / 60).ToString().PadLeft(2, '0')}:{(bekertDiak_erkezesePercben - bekertDiak_erkezesePercben / 60 * 60).ToString().PadLeft(2, '0')}";

            int bekertDiak_tavozasaPercben = Convert.ToInt32(esemenyKezelo.Esemenyek.Where(x => x.Tevekenyseg == 2 && x.Tanulokod == bekertDiakKodja).Select(x => x.Minute + x.Hour * 60));

            int hanypercetToltott_aSuliban = bekertDiak_tavozasaPercben - bekertDiak_erkezesePercben;

            int hanyOrat_toltott_aSuliban = hanypercetToltott_aSuliban / 60;
            int hanyPercet

            Console.WriteLine($"A tanuló érkezése és távozása között {} óra és {} perc telt el.");

        }
    }
}