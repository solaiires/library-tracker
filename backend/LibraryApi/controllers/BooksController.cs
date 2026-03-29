using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> BookStore = new List<Book>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(BookStore);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            book.Id = BookStore.Count + 1;
            BookStore.Add(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book updated)
        {
            var book = BookStore.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            book.Title = updated.Title;
            book.Author = updated.Author;
            book.IsRead = updated.IsRead;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookStore.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            BookStore.Remove(book);
            return Ok();
        }
    }
}