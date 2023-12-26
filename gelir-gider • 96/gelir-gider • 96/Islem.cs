using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gelir_gider___96
{
    internal class Islem
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public DateTime Tarih { get; set; }
        public string Tur { get; set; }
        public string Miktar { get; set; }
        public bool Gelir { get; set; }



        public Islem(int id, string tanim, DateTime tarih, string tur, string miktar, bool gelir )
        {
            Id = id;
            Tanim = tanim;
            Tarih = tarih;
            Tur = tur;
            Miktar = miktar;
            Gelir = gelir;


        }

    }
}
