using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Core.Entities;
using MovieCollection.Core.Interface;
using MovieCollection.Web.Models;
using MovieCollection.Web.Models.Movie;

namespace MovieCollection.Web.Controllers
{
    public class MoviesController : Controller
    {
        #region [ Members ]
        private const long PageSize = 10;
        private readonly IMapper _mapper;
        private readonly IRepository<Movie, MovieFilter, long> _movieRepository;
        #endregion

        #region [ Contructors ]
        public MoviesController(IMapper mapper,
            IRepository<Movie, MovieFilter, long> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        #endregion

        #region [ Methods ]
        [HttpGet]
        public async Task<IActionResult> Index(long pageIndex = 0, long pageSize = PageSize)
        {
            var movies = await _movieRepository.ReadAsync(
                new MovieFilter { PageIndex = pageIndex, PageSize = pageSize });

            return View(_mapper.Map<ListMovieViewModel>(movies));
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(long id)
        {
            var movie = (await _movieRepository.ReadAsync(x => x.Id == id))?.FirstOrDefault(); //TODO Упростить
            if (movie == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<DetailMovieViewModel>(movie));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet("Edit/{id}")]
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