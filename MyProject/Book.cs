using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }           //Kitap özellikleri tanımlamak için 
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Tür { get; set; }
        public string Durum { get; set; }

        public static void GetBooks(DbSet<Book> books) //tüm kitapları listelemek için oluşturulan method
        {
            Console.WriteLine("-------------------------------------------");
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.ISBN} -> {book.Baslik}");
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
        public static void RemoveBook(DbSet<Book> books)
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
        public static void CheckoutBook(List<Book> books)
        {
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
        public static void ReturnBook(List<Book> books)
        {
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
    }
}
