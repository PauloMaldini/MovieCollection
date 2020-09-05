using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Core.Entities;
using MovieCollection.Core.Interface;
using MovieCollection.Web.Models;
using MovieCollection.Web.Models.Movies;

namespace MovieCollection.Web.Controllers
{
    public class MoviesController : Controller
    {
        #region [ Members ]
        private const long PageSize = 10;
        private readonly IRepository<Movie, MovieFilter, long> _movieRepository;
        #endregion

        #region [ Contructors ]
        public MoviesController(IRepository<Movie, MovieFilter, long> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        #endregion

        #region [ Methods ]
        [HttpGet]
        public IActionResult Index(long pageIndex = 0, long pageSize = PageSize)
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(long id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet("{id}")]
        public IActionResult Edit(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(EditMovieViewModel model)
        {
            return View();
        }

        public IActionResult Delete(long id)
        {
            return View();
        }
        #endregion
    }
}