using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            using Context mycontext = new Context();
            //Kitapların listesi
            List<Book> books = new List<Book>
            {
                new Book{ISBN=140508,Baslik="Momo",Yazar="Michael Ende", Durum="Mevcut", Tür="Roman"},
                new Book{ISBN=12457,Baslik="Şeker Portakalı",Yazar="Jose Mauro de Vasconcelos", Durum="Ödünç Alındı", Tür="Roman"},
                new Book{ISBN=34589,Baslik="Milena'ya Mektuplar",Yazar="Franz Kafka", Durum="Ödünç Alındı", Tür="Roman"},
                new Book{ISBN=876543,Baslik="Suç ve Ceza",Yazar="Dostoyevski", Durum="Mevcut", Tür="Roman"},
                new Book{ISBN=012345,Baslik="Fahrenait 451",Yazar="Ray Bradbury", Durum="Mevcut", Tür="Roman"},
                new Book{ISBN=56774,Baslik="Ana",Yazar="Maksim Gorki", Durum="Ödünç Alındı", Tür="Roman"},
                new Book{ISBN=768965,Baslik="Ekmeğimi Kazanırken",Yazar="Maksim Gorki", Durum="Ödünç Alındı", Tür="Roman"},
                new Book{ISBN=61558,Baslik="Martin Eden",Yazar="Jack London", Durum="Mevcut", Tür="Roman"},
                new Book{ISBN=78454,Baslik="Yabancı",Yazar="Albert Camus", Durum="Mevcut", Tür="Roman"},
                new Book{ISBN=34567,Baslik="Kürk Mantolu Madonna",Yazar="Sabahattin Ali", Durum="Ödünç Alındı", Tür="Roman"},
            };
            //Müşterilerin listesi
            List<Patron> musteriler = new List<Patron>
            {
                new Patron{MusteriId=1,Ad="Berfin Ela Kılıç",Adres="Diyarbakır",TelNo=452635673},
                new Patron{MusteriId=2,Ad="Kürşat Doğan Çelik",Adres="Adana",TelNo=268545673},
                new Patron{MusteriId=3,Ad="Elif Gül",Adres="Mersin",TelNo=975654628},
                new Patron{MusteriId=4,Ad="Aram Kılıç",Adres="Diyarbakır",TelNo=975457274},
                new Patron{MusteriId=5,Ad="Ali Kaya",Adres="İzmir",TelNo=741355673},
                new Patron{MusteriId=6,Ad="Ahmet Gündoğdu",Adres="İstanbul",TelNo=1454767575},
            };

            //yapılacak kütüphane işlemi seçimi
            bool islemControl = true;
            do //Bir işlem bittikten sonra kullanıcı farklı bir işlem yapabilsin diye döngü oluşturuldu.
            {
                //Hangi sayı ile hangi işlemi yapacağımızı gösterir
                Console.WriteLine("İşlem 1- Tüm Kitaplar");
                Console.WriteLine("İşlem 2- Tüm Müşteriler");
                Console.WriteLine("İşlem 3- Kitap Ekleme");
                Console.WriteLine("İşlem 4- Kitap Silme");
                Console.WriteLine("İşlem 5- Müşteri Ekleme");
                Console.WriteLine("İşlem 6- Müşteri Silme");
                Console.WriteLine("İşlem 7- Kütüphaneden Kitap Ödünç Alma");
                Console.WriteLine("İşlem 8- Kütüphaneye Kitabı Geri Getirme");
                Console.WriteLine("İşlem 9- Ödünç Alınan Kitaplar Listesi");
                Console.WriteLine("İşlem 10- Kitap Arama");
                Console.WriteLine("İşlem 11- Müşteri Arama");

                Console.Write("İşlem: "); //yapmak istediğimiz işlem numarası girilir.
                int islem = Convert.ToInt32(Console.ReadLine());
                switch (islem)
                {
                    //her case farklı bir methodu çalıştırır.
                    case 1:
                        Console.WriteLine("----Tüm Kitaplar----");
                        Book.GetBooks(mycontext.books);
                        break;
                    case 2:
                        Console.WriteLine("----Tüm Müşteriler---- ");
                        Patron.GetPatrons(musteriler);
                        break;
                    case 3:
                        Console.WriteLine("----Kitap Ekleme----");
                        Book.AddBook(books);
                        break;
                    case 4:
                        Console.WriteLine("----Kitap Silme----");
                        Book.RemoveBook(mycontext.books);
                        break;
                    case 5:
                        Console.WriteLine("----Müşteri Ekleme----");
                        Patron.AddPatron(musteriler);
                        break;
                    case 6:
                        Console.WriteLine("----Müşteri Silme----");
                        Patron.RemovePatron(musteriler);
                        break;
                    case 7:
                        Console.WriteLine("----Kütüphaneden Kitap Ödünç Alma----");
                        Book.CheckoutBook(books);
                        break;
                    case 8:
                        Console.WriteLine("----Kütüphaneye Kitabı Geri Getirme----");
                        Book.ReturnBook(books);
                        break;
                    case 9:
                        Console.WriteLine("----Ödünç Alınan Kitaplar Listesi----");
                        Book.ListCheckedoutBooks(books);
                        break;
                    case 10:
                        Console.WriteLine("----Kitap Arama----");
                        Library.KitapArama(books);
                        break;
                    case 11:
                        Console.WriteLine("----Müşteri Arama----");
                        Library.MusteriArama(musteriler);
                        break;
                    default:
                        Console.WriteLine("Hatalı Giriş Yaptınız.");
                        break;
                }
                Console.Write("Çıkmak isterseniz Ç'ye basın: ");
                char devam = Convert.ToChar(Console.ReadLine());
                if (devam == 'Ç' || devam == 'ç')
                {
                    islemControl = false; //farklı bir işlem yapmak istemiyorsa döngüden çıksın 
                }
            } while (islemControl);
            mycontext.SaveChanges();
        }
    }
}