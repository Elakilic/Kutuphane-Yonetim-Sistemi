using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Patron
    {
        [Key]
        public int MusteriId { get; set; } //Müşteri özelliklerini tanımlamak için
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int TelNo { get; set; }
        public static void GetPatrons() //tüm müşterileri listelemek için oluşturulan method
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("-------------------------------------------");
                var patrons = context.musteriler.ToList();
                foreach (var patron in patrons)
                {
                    Console.WriteLine($"{patron.MusteriId} -> {patron.Ad}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
        public static void AddPatron()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                //Console.Write("Müşteri Id'si: ");
                //int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Müşteri Adı: ");
                string isim = Console.ReadLine();
                Console.Write("Müşteri Adresi: ");
                string adres = Console.ReadLine();
                Console.Write("Müşteri Telefon Numarası: ");
                int tel = Convert.ToInt32(Console.ReadLine());

                var newPatron = new Patron()
                {
                    //MusteriId = id,
                    Ad = isim,
                    Adres = adres,
                    TelNo = tel
                };

                context.musteriler.Add(newPatron); // Müşteriyi DbSet'e ekleyin
                context.SaveChanges(); // Değişiklikleri veritabanına kaydedin
                Console.WriteLine("Müşteri Eklendi.");
                Console.WriteLine("-------------------------------------------");

                var updatedPatrons = context.musteriler.ToList(); // Müşterileri güncel listeyi al
                foreach (var patron in updatedPatrons)
                {
                    Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
        public static void RemovePatron()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                bool control = true;
                do
                {
                    Console.WriteLine("-------------------------------------------");
                    var patrons = context.musteriler.ToList(); // Tüm müşterileri al
                    foreach (var patron in patrons)
                    {
                        Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
                    }
                    Console.WriteLine("-------------------------------------------");
                    Console.Write("Silmek istediğiniz müşteriyi Id'sine göre seçiniz: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var deletePatron = patrons.FirstOrDefault(patron => patron.MusteriId == id);

                    if (deletePatron != null)
                    {
                        context.musteriler.Remove(deletePatron); // Seçilen müşteriyi sil
                        context.SaveChanges(); // Değişiklikleri veritabanına kaydet
                        Console.WriteLine("Seçilen Müşteri Silindi.");
                        control = false;
                    }
                    else
                    {
                        Console.WriteLine("Müşteri Bulunamadı. Lütfen geçerli bir Müşteri Id girin.");
                    }
                } while (control);

                Console.WriteLine("-------------------------------------------");
                var updatedPatrons = context.musteriler.ToList(); // Güncel müşteri listesini al
                foreach (var patron in updatedPatrons)
                {
                    Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
