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

        public static void GetBooks() //tüm kitapları listelemek için oluşturulan method
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                var books = context.books.ToList(); // Tüm kitapları al
                Console.WriteLine("-------------------------------------------");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.ISBN} -> {book.Baslik}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
        public static void AddBook()
        {
            //Eklemek istenen kitap bilgisi kullanıcı tarafından girelecek.
            Console.Write("Kitap Başlığı: ");
            string baslik = Console.ReadLine();
            Console.Write("Kitap Yazarı: ");
            string yazari = Console.ReadLine();
            Console.Write("Kitap Türü: ");
            string türü = Console.ReadLine();

            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                var newBook = new Book()
                {
                    //ISBN = Isbn,
                    Baslik = baslik,
                    Yazar = yazari,
                    Durum = "Mevcut",
                    Tür = türü
                };

                context.books.Add(newBook); // Veriyi DbSet'e ekleyin
                context.SaveChanges(); // Değişiklikleri veritabanına kaydedin
            }
            Console.WriteLine("Kitap Eklendi.");
            Console.WriteLine("-------------------------------------------");
            using (var context = new Context())
            {
                var updatedBooks = context.books.ToList();
                foreach (var book in updatedBooks)
                {
                    Console.WriteLine($"Kitap ISBN'i: {book.ISBN} Kitap Adı: {book.Baslik}");
                }
            }
            Console.WriteLine("-------------------------------------------");
        }
        public static void RemoveBook()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                bool control = true;
                do
                {
                    Console.WriteLine("-------------------------------------------");
                    var books = context.books.ToList(); // Tüm kitapları al
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ISBN: {book.ISBN} Kitap Adı: {book.Baslik}");
                    }
                    Console.WriteLine("-------------------------------------------");
                    Console.Write("Silmek İstediğiniz kitabın ISBN'ini Seçiniz: ");
                    int isbn = Convert.ToInt32(Console.ReadLine());
                    var deleteBook = context.books.FirstOrDefault(x => x.ISBN == isbn);
                    if (deleteBook != null)
                    {
                        context.books.Remove(deleteBook); // Seçilen kitabı sil
                        context.SaveChanges(); // Değişiklikleri veritabanına kaydet
                        Console.WriteLine("Seçilen Kitap Silindi.");
                        control = false;
                    }
                    else
                    {
                        Console.WriteLine("Kitap Bulunamadı. Lütfen geçerli bir ISBN girin.");
                    }
                } while (control);

                var updatedBooks = context.books.ToList(); // Kitapları güncel listeyi al
                foreach (var book in updatedBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN} Kitap Adı: {book.Baslik}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }
        public static void CheckoutBook()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("----Mevcut Kitaplar Listesinden İstediğiniz Kitabı Seçebilirsiniz.----");
                Console.WriteLine("-------------------------------------------");

                var availableBooks = context.books.Where(book => book.Durum == "Mevcut").ToList();
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"Isbn: {book.ISBN}, Başlık: {book.Baslik}");
                }
                Console.WriteLine("-------------------------------------------");

                bool control = true;
                do
                {
                    Console.Write("Seçeceğiniz Kitabın ISBN'i: ");
                    int isbn = Convert.ToInt32(Console.ReadLine());

                    var selectedBook = availableBooks.FirstOrDefault(book => book.ISBN == isbn);

                    if (selectedBook != null)
                    {
                        selectedBook.Durum = "Ödünç Alındı";
                        context.SaveChanges(); // Kitap durumunu güncellemek için veritabanına kaydet
                        control = false;
                    }
                    else
                    {
                        Console.WriteLine("Kitap Bulunamadı veya Ödünç Alındı.");
                    }
                } while (control);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Kitap Ödünç Alındı.");
                Console.WriteLine("-------------------------------------------");
            }
        }
    
        public static void ReturnBook()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("----Ödünç Alınan Kitaplar Listesinden İade Etmek İstediğiniz Kitabı Seçebilirsiniz.----");
                Console.WriteLine("-------------------------------------------");

                var borrowedBooks = context.books.Where(book => book.Durum == "Ödünç Alındı").ToList();
                foreach (var book in borrowedBooks)
                {
                    Console.WriteLine($"Isbn: {book.ISBN}, Başlık: {book.Baslik}");
                }
                Console.WriteLine("-------------------------------------------");

                bool control2 = true;
                do
                {
                    Console.Write("İade Etmek İstediğiniz Kitap ISBN'i: ");
                    int isbn = Convert.ToInt32(Console.ReadLine());

                    var returnedBook = borrowedBooks.FirstOrDefault(book => book.ISBN == isbn);

                    if (returnedBook != null)
                    {
                        returnedBook.Durum = "Mevcut";
                        context.SaveChanges(); // Kitap durumunu güncellemek için veritabanına kaydet
                        control2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Kitap Bulunamadı veya Zaten Mevcut Durumda.");
                    }
                } while (control2);

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Kitap İade Edildi.");
                Console.WriteLine("-------------------------------------------");
            }
        }
        public static void ListCheckedoutBooks()
        {
            using (var context = new Context()) // DbContext'i kullanarak bağlanın
            {
                Console.WriteLine("----Ödünç Alınan Kitaplar----");
                var checkedoutBooks = context.books.Where(book => book.Durum == "Ödünç Alındı").ToList();
                foreach (var book in checkedoutBooks)
                {
                    Console.WriteLine(book.Baslik);
                }
            }
        }
    }
}
