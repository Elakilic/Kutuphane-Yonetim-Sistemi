using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Patron
    {
        public int MusteriId { get; set; } //Müşteri özelliklerini tanımlamak için  
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int TelNo { get; set; }
        public static void OduncAlinanlar(List<Book> books)
        {
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books) //Ödünç alınan kitapları listeler
            {
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine(book.Baslik);

                }
            }
        }
    }
}
