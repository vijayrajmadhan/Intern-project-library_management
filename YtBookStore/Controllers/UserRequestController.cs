using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;
using YtBookStore.Repositories.Implementation;

namespace YtBookStore.Controllers
{
    public class UserRequestController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        private readonly ITakeBookService takebookService;

        public UserRequestController(IBookService bookService, IGenreService genreService, IPublisherService publisherService, IAuthorService authorService, ITakeBookService takebookService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.authorService = authorService;
            this.takebookService = takebookService;
        }
        public IActionResult GetAll()
        {
            var data = takebookService.GetAll();
            return View(data);
        }

        public IActionResult Update(int id)
        {
            var model = takebookService.FindById(id);
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(TakeBook model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = takebookService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public async Task<IActionResult> SearchRequest(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var User = from b in takebookService.GetAll()
                       select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                User = User.Where(b => b.BookCode.Contains(SearchString));
            }
            return View(User);
        }

        public IActionResult Delete(int id)
        {

            var result = takebookService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}
