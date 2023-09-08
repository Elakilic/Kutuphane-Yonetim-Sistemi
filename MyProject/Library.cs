using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Library
    {       
        public static void KitapArama()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("-------------------------------------------");
                var books = context.books.ToList(); // Tüm kitapları al
                foreach (var book in books)
                {
                    Console.WriteLine("Başlık: " + book.Baslik);
                }
                Console.WriteLine("-------------------------------------------");

                bool control = true;
                do
                {
                    Console.Write("Arayacağınız Kitabın Başlığı: ");
                    string baslik = Console.ReadLine();
                    var foundBook = books.FirstOrDefault(book => book.Baslik == baslik);

                    if (foundBook != null)
                    {
                        Console.WriteLine("Aradığınız Kitap Bulundu. ");
                        Console.WriteLine($"Kitabın Başlığı: {foundBook.Baslik}, ISBN'i: {foundBook.ISBN}, Durumu: {foundBook.Durum}, Yazarı: {foundBook.Yazar}, Türü: {foundBook.Tür}");
                        control = false;
                    }
                    else
                    {
                        Console.WriteLine("Aradığınız kitap bulunamadı. Lütfen geçerli bir kitap başlığı girin.");
                    }
                } while (control);
            }
        }
        public static void MusteriArama()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("-------------------------------------------");
                var musteriler = context.musteriler.ToList(); // Tüm müşterileri al
                foreach (var musteri in musteriler)
                {
                    Console.WriteLine("Müşteri ID: " + musteri.MusteriId);
                }
                Console.WriteLine("-------------------------------------------");

                bool control2 = true;
                do
                {
                    Console.Write("Arayacağınız Müşterinin ID'si: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var foundMusteri = musteriler.FirstOrDefault(musteri => musteri.MusteriId == id);

                    if (foundMusteri != null)
                    {
                        Console.WriteLine("Aradığınız Müşteri Bulundu.");
                        Console.WriteLine($"Müşterinin ID'si: {foundMusteri.MusteriId}, Adı: {foundMusteri.Ad}, Adresi: {foundMusteri.Adres}, Telefonu: {foundMusteri.TelNo}");
                        control2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Aradığınız müşteri bulunamadı. Lütfen geçerli bir Müşteri ID girin.");
                    }
                } while (control2);
            }
        }
    }
}
