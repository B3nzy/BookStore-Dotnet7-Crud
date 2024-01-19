using BookStore.DbContexts;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            using(var context = new BookDbContext())
            {
                List<Book> books = context.Books.ToList();
                return View(books);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string title, string author, int price, int quantity)
        {
            Console.WriteLine(title + " " + author + " " + price + " " + quantity);
            using(var context = new BookDbContext())
            {
                context.Books.Add(new Book { Title=title, Author=author, Price=price, Qunatity=quantity });
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Console.WriteLine($"{id}");
            using(var context = new BookDbContext())
            {
                Book book = context.Books.Find(id);
                return View(book);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id,string title, string author, int price, int quantity)
        {
            Console.WriteLine(id+" "+title + " " + author + " " + price + " " + quantity);
            using (var context = new BookDbContext())
            {
                Book book = context.Books.Find(id);
                book.Title = title;
                book.Author = author;
                book.Price = price;
                book.Qunatity = quantity;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using(var context = new BookDbContext())
            {
                context.Books.Remove(new Book { Id=id});
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
