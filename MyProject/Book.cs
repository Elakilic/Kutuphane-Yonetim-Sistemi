using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Book
    {
        public int ISBN { get; set; }           //Kitap özellikleri tanımlamak için 
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Tür { get; set; }
        public string Durum { get; set; }
    }
}
