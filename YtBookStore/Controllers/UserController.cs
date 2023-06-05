
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;

namespace YtBookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        private readonly ITakeBookService takebookService;

        public UserController(IBookService bookService, IGenreService genreService, IPublisherService publisherService, IAuthorService authorService, ITakeBookService takebookService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.authorService = authorService;
            this.takebookService = takebookService;
        }

        public IActionResult GetAll()
        {

            var data = bookService.GetAll();
            return View(data);
        }
        public IActionResult Index2()
        {
            return View();
        }
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var books = from b in bookService.GetAll()
                        select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString));
            }
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var obj = bookService.FindById(id);


            // Pass the image link to the view
            // return View(imageLink);
            return View(obj);
        }

        public IActionResult Add()
        {
            var model = new TakeBook();
            return View(model);
        }


        [HttpPost]
        public IActionResult Add(TakeBook model)
        {
            

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = takebookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
               TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult RequestStatus()
        {
            var data = takebookService.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Search(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var User = from b in takebookService.GetAll()
                        select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                User = User.Where(b => b.AadharNo.Contains(SearchString));
            }
            return View(User);
        }
    }
}
