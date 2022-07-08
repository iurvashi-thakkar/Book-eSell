using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreApi1.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        BookRepository _bookRepository = new BookRepository();
        [HttpGet]
        [Route("list")]
        public IActionResult GetBooks(int pageIndex=1, int pageSize=10,string? keyword="")
        {
            var books=_bookRepository.GetBooks(pageIndex, pageSize, keyword);
            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                Results = books.Results.Select(c => new BookModel(c)),
                TotalRecords = books.TotalRecords,

            };
            return Ok(listResponse);
        }
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if(book==null)
                return NotFound();

            BookModel bookModel = new BookModel(book);
            return Ok(bookModel);
        }
        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult Addbook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");
            Book book = new Book()
            {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price,
            Description = model.Description,
            Base64image = model.Base64image,
            Categoryid = model.Categoryid,
            Publisherid = model.Publisherid,
            Quantity = model.Quantity
        };
            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);
            return Ok(bookModel);
        }
        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is Null");

            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity
            };
            var response = _bookRepository.UpdateBook(book);
            BookModel bookModel = new BookModel(response);
            return Ok(bookModel);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest("ID is Null");
            var response = _bookRepository.DeleteBook(id);
            return Ok(response);
        }
    }
}
