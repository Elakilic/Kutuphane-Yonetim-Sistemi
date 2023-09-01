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
                //Hangi sayı ile hangi işlemi yapacağımızı gösterir.
                Console.WriteLine("İşlem 1- Ödünç Alınan Kitaplar Listesi");
                Console.WriteLine("İşlem 2- Tüm Kitaplar");
                Console.WriteLine("İşlem 3- Tüm Müşteriler");
                Console.WriteLine("İşlem 4- Kitap Ekleme");
                Console.WriteLine("İşlem 5- Kitap Silme");
                Console.WriteLine("İşlem 6- Müşteri Ekleme");
                Console.WriteLine("İşlem 7- Müşteri Silme");
                Console.WriteLine("İşlem 8- Kütüphaneden Kitap Ödünç Alma");
                Console.WriteLine("İşlem 9- Kütüphaneye Kitabı Geri Getirme");
                Console.WriteLine("İşlem 10- Ödünç Alınan Kitaplar Listesi");
                Console.WriteLine("İşlem 11- Arama");

                Console.Write("İşlem: "); //yapmak istediğimiz işlem numarası girilir.
                int islem = Convert.ToInt32(Console.ReadLine());
                switch (islem)
                {
                    //her case farklı bir methodu çalıştırır.
                    case 1: 
                        Console.WriteLine("----Ödünç Alınan Kitaplar Listesi----");
                        Patron.OduncAlinanlar(books);
                        break;
                    case 2:
                        Console.WriteLine("----Tüm Kitaplar---- ");
                        Library.GetBooks(books);
                        break;
                    case 3:
                        Console.WriteLine("----Tüm Müşteriler----");
                        Library.GetPatrons(musteriler);
                        break;
                    case 4:
                        Console.WriteLine("----Kitap Ekleme----");
                        Library.AddBook(books);
                        break;
                    case 5:
                        Console.WriteLine("----Kitap Silme----");
                        Library.RemoveBook(books);
                        break;
                    case 6:
                        Console.WriteLine("----Müşteri Ekleme----");
                        Library.AddPatron(musteriler);
                        break;
                    case 7:
                        Console.WriteLine("----Müşteri Silme----");
                        Library.RemovePatron(musteriler);
                        break;
                    case 8:
                        Console.WriteLine("----Kütüphaneden Kitap Ödünç Alma----");
                        Library.CheckoutBook(books, musteriler);
                        break;
                    case 9:
                        Console.WriteLine("----Kütüphaneye Kitabı Geri Getirme----");
                        Library.ReturnBook(books, musteriler);
                        break;
                    case 10:
                        Console.WriteLine("----Ödünç Alınan Kitaplar Listesi----");
                        Library.ListCheckedoutBooks(books);
                        break;
                    case 11:
                        Console.WriteLine("----Kitap ve Müşteri Arama----");
                        Library.Arama(books, musteriler);
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
        }

    }

    public class Book
    {
        public int ISBN { get; set; }           //Kitap özellikleri tanımlamak için 
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Tür { get; set; }
        public string Durum { get; set; }
    }

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

    public class Library 
    {
        public static void GetBooks(List<Book> books) //tüm kitapları listelemek için oluşturulan method
        {
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.ISBN} -> {book.Baslik}");
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void GetPatrons(List<Patron> musteriler) //tüm müşterileri listelemek için oluşturulan method
        {
            Console.WriteLine("-------------------------------------------");
            foreach (var patron in musteriler)
            {
                Console.WriteLine($"{patron.MusteriId} -> {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void AddBook(List<Book> books) 
        {
            Console.Write("Kitap ISBN'i: ");
            int Isbn = Convert.ToInt32(Console.ReadLine());  //Eklemek istenen kitap bilgisi kullanıcı tarafından girelecek.
            Console.Write("Kitap Başlığı: ");
            string baslik=Console.ReadLine();
            Console.Write("Kitap Yazarı: ");
            string yazari =Console.ReadLine();
            Console.Write("Kitap Türü: ");
            string türü=Console.ReadLine();

            books.Add(new Book() {ISBN=Isbn, Baslik=baslik,Yazar=yazari, Durum= "Mevcut", Tür=türü}); //Bilgiler girildikten sonra ekleme yapar.
            Console.WriteLine("Kitap Eklendi.");
            Console.WriteLine("-------------------------------------------");
            foreach (Book book in books) //kitap eklendikten sonraki yeni kitap listesi
            {
                Console.WriteLine($"Kitap ISBN'i: {book.ISBN} Kitap Adı: {book.Baslik}");
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void RemoveBook(List<Book> books)
        {
            bool control = true;
            do //Kitap bilgisi yanlış girilirse tekrar girmek için döngü oluşturuldu.
            {
                Console.WriteLine("-------------------------------------------");
                foreach (Book book in books) //Sileceğimiz kitabı seçmek için kitaplar kullanıcıya gösterilir
                {
                    Console.WriteLine($"ISBN: {book.ISBN} Kitap Adı: {book.Baslik}");
                }
                Console.WriteLine("-------------------------------------------");
                Console.Write("Silmek İstediğiniz kitabın ISBN'ini Seçiniz: ");
                int isbn = Convert.ToInt32(Console.ReadLine()); //silmek istediğimiz kitap seçilir
                foreach(Book book in books)
                {
                    if (book.ISBN == isbn)
                    {
                        var deleteBook = books.FirstOrDefault(x => x.ISBN == isbn);
                        books.Remove(deleteBook); //seçtiğimiz kitap silinir.
                        Console.WriteLine("Seçtiğiniz Kitap Silindi.");
                        control = false;
                        break;
                    }
                }
            } while( control );

            foreach(Book book in books) //kitap silindikten sonraki yeni kitap listesi
            {
                Console.WriteLine($"ISBN: {book.ISBN} Kitap Adı: {book.Baslik}");
            }
        }
        public static void AddPatron(List<Patron> musteriler)
        {
            Console.Write("Müşteri Id'si: ");                     //müşteri eklemek için kullanıcıdan bilgiler alınır
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşteri Adı: ");
            string isim=Console.ReadLine();
            Console.Write("Müşteri Adresi: ");
            string adres=Console.ReadLine();
            Console.Write("Müşteri Telefon NUmarası: ");
            int tel = Convert.ToInt32(Console.ReadLine());

            musteriler.Add(new Patron() {MusteriId=id, Ad=isim, Adres=adres, TelNo=tel}); //Müşteri eklenir
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
        public static void CheckoutBook(List<Book> books , List<Patron> musteriler)
        {
            Console.WriteLine("-------------------------------------------");
            foreach (Patron patron in musteriler) //Müşterileri Listeler
            {
                Console.WriteLine($"Müşteri ID'si: {patron.MusteriId} Adı: {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
            Console.Write("Müşteri Id'sine göre seçim yapınız: "); //Hangi Müşteri kitabı ödünç alacak
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var patron in musteriler)
            {
                if (id == patron.MusteriId)
                {
                    Console.WriteLine("Müşteri Adı: " + patron.Ad);
                }
            }
            Console.WriteLine("----Mevcut Kitaplar Listesinden İstediğiniz Kitabı Seçebilirsiniz.----");
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books) //Mevcut Kitapları kullanıcıya göster, kullanıcının bu kitaplardan seçim yapması için
            {
                if (book.Durum == "Mevcut")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            Console.WriteLine("-------------------------------------------");
            bool control = true; //do-while controlu için
            do
            {

                Console.Write("Seçeceğiniz Kitabın ISBN'i: "); //Kullanıcı kitabı seçer
                int key2 = Convert.ToInt32(Console.ReadLine());
                foreach (var book in books)
                {
                    if (key2 == book.ISBN) //Seçilen kitabın ISBN'i doğru girildiyse kitap seçilir. Yanlış girildiyse tekrar seçmesini ister
                    {
                        if (book.Durum.Equals("Mevcut"))
                        {
                            book.Durum = book.Durum.Replace("Mevcut", "Ödünç Alındı"); //kitap durumunu güncellemek için
                        }
                        control=false; //döngüden çıkmak için
                    }
                }
            } while (control);
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books) //Kitap ödünç verildikten sonraki güncel Mevcut kitaplar listesi
            {
                if (book.Durum == "Mevcut")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void ReturnBook(List<Book> books , List<Patron> musteriler)
        {
            Console.WriteLine("-------------------------------------------");
            foreach (Patron patron in musteriler) //Hangi müşterinin kitabı geri getireceğini belirt
            {
                Console.WriteLine($"Müşteri ID'si: {patron.MusteriId} Adı: {patron.Ad}");
            }
            Console.WriteLine("-------------------------------------------");
            Console.Write("Müşteri Id'sine göre seçim yapınız: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var patron in musteriler)
            {
                if (id == patron.MusteriId)
                {
                    Console.WriteLine("Müşteri Adı: " + patron.Ad);
                }
            }
            Console.WriteLine("----Ödünç Alınan Kitaplar Listesinden İade Etmek İstediğiniz Kitabı Seçebilirsiniz.----");
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books) //ödünç alınan kitapları listeleyip kullanıcının hangi kitabı getireceğini seçmesi için
            {
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            Console.WriteLine("-------------------------------------------");
            bool control2 = true; //do-while kontrolü için
            do
            {           
                Console.Write("İade Etmek İstediğiniz Kitap ISBN'i: "); //iade etmek istediği kitap hangisi?
                int key = Convert.ToInt32(Console.ReadLine());
                foreach (var book in books)
                {
                    if (key == book.ISBN) //ISBN doğru girildiyse kitabı iade eder, doğru girilmezse tekrar girmesini ister.
                    {
                        if (book.Durum.Equals("Ödünç Alındı"))
                        {
                            book.Durum = book.Durum.Replace("Ödünç Alındı", "Mevcut"); //Kitap durumunu güncellemek için
                        }
                        control2 = false; //döngüden çıkması için
                    }
                }
            } while (control2);
            Console.WriteLine("-------------------------------------------");
            foreach (var book in books) //Müşteri kitabı geri getirdikten sonraki güncel Ödünç Alınan kitaplar listesi
            {
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine("Isbn: " + book.ISBN + ", Başlık: " + book.Baslik);

                }
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void ListCheckedoutBooks(List<Book> books)
        {
            Console.WriteLine("----Ödünç Alınan Kitaplar----");
            foreach (var book in books)
            {
                if(book.Durum =="Ödünç Alındı")
                {
                    Console.WriteLine(book.Baslik);
                }
            }
        }
        public static void Arama(List<Book> books, List<Patron> musteriler)
        {
            Console.Write("Kitap aramak için K, Müşteri aramak için M tuşlayınız: ");
            char secim =Convert.ToChar(Console.ReadLine());
            if(secim == 'k' || secim == 'K')
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
            else if(secim == 'm' || secim == 'M')
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
            else
            {
                Console.WriteLine("Yanlış girdiniz");
            }
        }
    }
}