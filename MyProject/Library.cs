using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Library
    {       
        public static void KitapArama(List<Book> books)
        {
            Console.WriteLine("-------------------------------------------");
            foreach (Book book in books) //Kitap Başlığına göre kitap arama
            {
                Console.WriteLine("Başlık: " + book.Baslik);
            }
            Console.WriteLine("-------------------------------------------");
            bool control = true;
            do //kitap adı yanlış girilirse tekrar girebilmek için döngü oluşturuldu.
            {
                Console.Write("Arayacağınız Kitabın Başlığı: ");
                string baslik = Console.ReadLine();
                foreach (var book in books)
                {
                    if (book.Baslik == baslik)
                    {
                        Console.WriteLine("Aradığınız Kitap Bulundu. ");
                        Console.WriteLine($"Kitabın Başlığı: {book.Baslik} , ISBN'i: {book.ISBN} , Durumu: {book.Durum} , Yazarı: {book.Yazar} ," +
                            $"Türü: {book.Tür} ");
                        control = false; //döngüden çıkması için
                    }
                }
            } while (control);            
        }
        public static void MusteriArama(List<Patron> musteriler)
        {
            Console.WriteLine("-------------------------------------------");
            foreach (var musteri in musteriler) //müşteri idsine göre arama
            {
                Console.WriteLine("Müşteri ID: " + musteri.MusteriId);
            }
            Console.WriteLine("-------------------------------------------");
            bool control2 = true;
            do //müşteri idsi yanlış girilirse tekrar girebilmek için döngü oluşturuldu.
            {
                Console.Write("Arayacağınız Müşterinin ID'si: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (var musteri in musteriler)
                {
                    if (musteri.MusteriId == id)
                    {
                        Console.WriteLine("Aradığınız Müşteri Bulundu.");
                        Console.WriteLine($"Müşterinin ID'si: {musteri.MusteriId} , Adı: {musteri.Ad} , Adresi: {musteri.Adres} , Telefonu: {musteri.TelNo}");
                        control2 = false; //döngüden çıkması için
                    }

                }
            } while (control2);
        }
    }
}
