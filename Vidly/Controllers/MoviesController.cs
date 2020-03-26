using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            

            if (User.IsInRole(Rolename.CanManageMovies))


                return View("List");

            else
                return View("ReadOnlyList");
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [Authorize(Roles = Rolename.CanManageMovies)]
        public ActionResult New()

        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                genre = genre

            };
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rolename.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                movie.DateAdded = DateTime.Now;


            }
            else
            {


                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = Rolename.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)

                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {


                genre = _context.Genres.ToList()

            };
            return View("MoviesForm", viewModel);

        }

    }
}