using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto.Models
{
    internal class EsemenyKezelo
    {
        private List<Esemeny> esemenyek = new();

        public List<Esemeny> Esemenyek { get => esemenyek; set => esemenyek = value; }

        public void LoadFromData(String path)
        {
            File.ReadAllLines(path).ToList().ForEach(x => Esemenyek.Add(new Esemeny(x)));
        }
        public List<String> EbedelokKodjai()
        {

           return Esemenyek.Where(x => x.Tevekenyseg == 3).Select(x => x.Tanulokod).ToList();


        }
        public List<Esemeny> GetEsemenyek(int esemenyFajta)
        {
            return Esemenyek.Where(x => x.Tevekenyseg == esemenyFajta).ToList();
        }

        public List<String> KikVoltakIskolaban(int kezdoOra, int kezdoPerc, int zaroOra, int zaroPerc)
        {
            
            return Esemenyek.Where(x => x.Hour * 60 + x.Minute < kezdoOra * 60 + kezdoPerc 
                                    && x.Hour * 60 + x.Minute > zaroOra * 60 + zaroPerc)
                            .Select(x => x.Tanulokod).ToList();
        }

        
    }
}
