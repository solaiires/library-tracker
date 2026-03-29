using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models; // for Book
using LibraryApi.Data;   // for LibraryContext
using System.Linq;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList(); // read from database
            return Ok(books);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult Add(Book book)
        {
            _context.Books.Add(book);   // add to database
            _context.SaveChanges();     // persist changes
            return Ok(book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book updated)
        {
            var book = _context.Books.Find(id); // find in database
            if (book == null) return NotFound();

            book.Title = updated.Title;
            book.Author = updated.Author;
            book.IsRead = updated.IsRead;

            _context.SaveChanges(); // persist update
            return Ok(book);
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges(); // persist deletion
            return Ok();
        }
    }
}