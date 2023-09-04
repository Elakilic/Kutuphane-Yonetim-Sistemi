using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
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
            string baslik = Console.ReadLine();
            Console.Write("Kitap Yazarı: ");
            string yazari = Console.ReadLine();
            Console.Write("Kitap Türü: ");
            string türü = Console.ReadLine();

            books.Add(new Book() { ISBN = Isbn, Baslik = baslik, Yazar = yazari, Durum = "Mevcut", Tür = türü }); //Bilgiler girildikten sonra ekleme yapar.
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
                foreach (Book book in books)
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
            } while (control);

            foreach (Book book in books) //kitap silindikten sonraki yeni kitap listesi
            {
                Console.WriteLine($"ISBN: {book.ISBN} Kitap Adı: {book.Baslik}");
            }
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
        public static void CheckoutBook(List<Book> books, List<Patron> musteriler)
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
                        control = false; //döngüden çıkmak için
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
        public static void ReturnBook(List<Book> books, List<Patron> musteriler)
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
                if (book.Durum == "Ödünç Alındı")
                {
                    Console.WriteLine(book.Baslik);
                }
            }
        }
        public static void Arama(List<Book> books, List<Patron> musteriler)
        {
            Console.Write("Kitap aramak için K, Müşteri aramak için M tuşlayınız: ");
            char secim = Convert.ToChar(Console.ReadLine());
            if (secim == 'k' || secim == 'K')
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
            else if (secim == 'm' || secim == 'M')
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
