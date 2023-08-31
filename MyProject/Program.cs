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
            Console.Write("İşlem: ");
            int islem =Convert.ToInt32(Console.ReadLine());

            bool islemControl = true;
            do
            {
                switch (islem)
                {

                    case 1:

                        Console.WriteLine("----Ödünç Alınan Kitaplar Listesi----");
                        Patron.OduncAlinanlar(books);                                                   
                        islemControl = false;
                        break;
                    case 2:
                        Console.WriteLine("----Tüm Kitaplar---- ");
                        Library.GetBooks(books);
                        islemControl = false;
                        break;
                    case 3:
                        Console.WriteLine("----Tüm Müşteriler----");
                        Library.GetPatrons(musteriler);
                        islemControl = false;
                        break;
                    case 4:
                        Console.WriteLine("----Kitap Ekleme----");
                        Library.AddBook(books);
                        islemControl = false;
                        break;
                    case 5:
                        Console.WriteLine("----Kitap Silme----");
                        Library.RemoveBook();
                        islemControl = false;
                        break;
                    case 6:
                        Console.WriteLine("----Müşteri Ekleme----");
                        Library.AddPatron();
                        islemControl = false;
                        break;
                    case 7:
                        Console.WriteLine("----Müşteri Silme----");
                        Library.RemovePatron();
                        islemControl = false;
                        break;
                    case 8:
                        Console.WriteLine("----Kütüphaneden Kitap Ödünç Alma----");
                        Library.CheckoutBook(books);
                        islemControl = false;
                        break;
                    case 9:
                        Console.WriteLine("----Kütüphaneye Kitabı Geri Getirme----");
                        Library.ReturnBook(books);
                        islemControl = false;
                        break;
                    case 10:
                        Console.WriteLine("----Ödünç Alınan Kitaplar Listesi----");
                        Library.ListCheckedoutBooks(books);
                        islemControl = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı Giriş Yaptınız.");
                        islemControl = false;
                        break;
                }
            } while (islemControl);
        }

    }

    public class Book
    {
        public int ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Tür { get; set; }
        public string Durum { get; set; }


    }

    public class Patron
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int TelNo { get; set; }
        public static List<Book> OduncAlinanlar(List<Book> books)
        {
            List<Book> odunc = new List<Book>();
            Console.WriteLine("----Ödünç Alınan Kitaplar----");
            foreach (var book in books)
            {
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine(book.Baslik);

                }
            }
            return odunc;
        }
    }

    public class Library 
    {
        public static void GetBooks(List<Book> books) 
        {
            List<Book> tumKitaplar = new List<Book>();
            Console.WriteLine("----Tüm Kitaplar-----");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.ISBN} -> {book.Baslik}");
            }
        }
        public static void GetPatrons(List<Patron> patrons)
        {
            List<Patron> musteriler = new List<Patron>();
            Console.WriteLine("----Tüm Müşteriler----");
            foreach(var patron in patrons)
            {
                Console.WriteLine($"{patron.MusteriId} -> {patron.Ad}");

            }

            Console.Write("Müşteri Id'sine göre seçim yapınız: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach(var patron in patrons)
            {
                if(id == patron.MusteriId)
                {
                    Console.WriteLine("Müşteri Adı: " + patron.Ad);
                }    
            }
        }
        public static void AddBook(List<Book> books) 
        {
            Console.Write("Kitap ISBN'i: ");
            int Isbn = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kitap Başlığı: ");
            string baslik=Console.ReadLine();
            Console.Write("Kitap Yazarı: ");
            string yazari =Console.ReadLine();
            Console.Write("Kitap Türü: ");
            string türü=Console.ReadLine();

            books.Add(new Book() {ISBN=Isbn, Baslik=baslik,Yazar=yazari, Durum= "Mevcut", Tür=türü});
            Console.WriteLine("Kitap Eklendi.");

            foreach(Book book in books)
            {
                Console.WriteLine($"Kitap ISBN'i: {book.ISBN} Kitap Adı: {book.Baslik}");
            }
            
        }
        public static void RemoveBook()
        {
            List<Book> books = new List<Book>();
            books.Remove(new Book() { ISBN=56774});

        }
        public static void AddPatron()
        {
            List<Patron> patrons = new List<Patron>();
            patrons.Add(new Patron() { MusteriId = 7, Ad = "Aziz Çiçek", Adres = "Hatay", TelNo = 344689878 });
        }
        public static void RemovePatron()
        {
            List<Patron> patrons=new List<Patron>();
            patrons.Remove(new Patron() { MusteriId = 5 });


        }
        public static void CheckoutBook(List<Book> books )
        {
            Console.WriteLine("----Mevcut Kitaplar Listesinden İstediğiniz Kİtabı Seçebilirsiniz.----");
            foreach (var book in books)
            {
                if (book.Durum == "Mevcut")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            bool control = true; //do-while controlu için
            do
            {

                Console.Write("Seçeceğiniz Kitabın ISBN'i: ");
                int key2 = Convert.ToInt32(Console.ReadLine());
                foreach (var book in books)
                {
                    if (key2 == book.ISBN)
                    {
                        book.Durum.Replace("Mevcut", "Ödünç Alındı");
                        Console.WriteLine("İstediğiniz Kitap Ödünç Alındı. " + "Kitap Adı: " + book.Baslik);
                        control = false; //döngüden çıkması için
                    }

                }
            } while (control);
            
        }
        public static List<Book> ReturnBook(List<Book> books)
        {
            Console.WriteLine("----Ödünç Alınan Kitaplar Listesinden İade Etmek İstediğiniz Kitabı Seçebilirsiniz.----");
            foreach (var book in books)
            {
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            bool control2 = true; //do-
            do
            {
            
                Console.Write("İade Etmek İstediğiniz Kitap: ");
                int key = Convert.ToInt32(Console.ReadLine());
                foreach (var book in books)
                {
                    if (key == book.ISBN)
                    {
                        book.Durum.Replace("Ödünç Alındı", "Mevcut");
                        Console.WriteLine("Kitap iade edildi. " + "Kitap Adı: " + book.Baslik);
                        control2 = false;
                    }

                }
            } while (control2);
            return books;

        }
        public static List<Book> ListCheckedoutBooks(List<Book> books)
        {
            Console.WriteLine("----Ödünç Alınan Kitaplar----");
            foreach (var book in books)
            {
                if(book.Durum =="Ödünç Alındı")
                {
                    Console.WriteLine(book.Baslik);
                }
            }
            return books;
        }

    }
}