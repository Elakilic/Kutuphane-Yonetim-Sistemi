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
        public static void GetPatrons(List<Patron> musteriler) //tüm müşterileri listelemek için oluşturulan method
        {
            Console.WriteLine("-------------------------------------------");
            foreach (var patron in musteriler)
            {
                Console.WriteLine($"{patron.MusteriId} -> {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void AddPatron(List<Patron> musteriler)
        {
            Console.Write("Müşteri Id'si: ");                     //müşteri eklemek için kullanıcıdan bilgiler alınır
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşteri Adı: ");
            string isim = Console.ReadLine();
            Console.Write("Müşteri Adresi: ");
            string adres = Console.ReadLine();
            Console.Write("Müşteri Telefon NUmarası: ");
            int tel = Convert.ToInt32(Console.ReadLine());

            musteriler.Add(new Patron() { MusteriId = id, Ad = isim, Adres = adres, TelNo = tel }); //Müşteri eklenir
            Console.WriteLine("Müşteri Eklendi.");
            Console.WriteLine("-------------------------------------------");
            foreach (Patron patron in musteriler) //müşteri eklendikten sonra yeni müşteri listesini gösterir.
            {
                Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void RemovePatron(List<Patron> musteriler)
        {
            bool control = true;
            do //Müşteri bilgisi yanlış girilirse tekrar girsin diye döngü oluşturuldu.
            {
                Console.WriteLine("-------------------------------------------");
                foreach (Patron patron in musteriler) //Hangi müşteriyi sileceğini seçmesi için müşterileri listeler
                {
                    Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
                }
                Console.WriteLine("-------------------------------------------");
                Console.Write("Silmek istediğiniz müşteriyi Id'sine göre seçiniz: "); //silinecek müşteri seçilir
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Patron patron in musteriler)
                {
                    if (patron.MusteriId == id)
                    {
                        var deletePatron = musteriler.FirstOrDefault(x => x.MusteriId == id);
                        musteriler.Remove(deletePatron); //müşteri silindi
                        Console.WriteLine("Seçtiğiniz Müşteri Silindi.");
                        control = false;
                        break;
                    }
                }
            } while (control);
            Console.WriteLine("-------------------------------------------");
            foreach (Patron patron in musteriler) //müşteri silindikten sonraki müşteri listesini gösterir
            {
                Console.WriteLine($"Müşteri Id'si: {patron.MusteriId}  Müşteri Adı: {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
        }
    }
}
