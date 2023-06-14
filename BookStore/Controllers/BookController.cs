using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }


        // GET: /<controller>/
        //Add method
        public IActionResult Add()
        {
            var model = new Book();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var data = bookService.Add(model);
            if (data)
            {
                TempData["msg"] = "Book Added Successfully.";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to add book.";
            return View(model);
        }


        //Update method

        public IActionResult Update(int id)
        {
            var model = bookService.FindById(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var data = bookService.Update(model);
            if (data)
            {
                TempData["msg"] = "Updated Successfully.";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to update book.";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = bookService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var result = bookService.GetAll().OrderBy(data => data.Name).ToList();
            return View(result);
        }


        public IActionResult GetBySearch(string searchQuery)
        {
            var result = bookService.GetAll().Where(x => x.Name.ToLower().Contains(searchQuery.ToLower()));
            return View(result);
        }
    }
}

