using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IWebHostEnvironment _environment;
        private readonly IRepository<Movie, MovieFilter, long> _movieRepository;
        private readonly IRepository<Producer, ProducerFilter, long> _producerRepository;
        #endregion

        #region [ Contructors ]
        public MoviesController(IMapper mapper,
            IWebHostEnvironment environment,
            IRepository<Movie, MovieFilter, long> movieRepository,
            IRepository<Producer, ProducerFilter, long> producerRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _producerRepository = producerRepository;
            _environment = environment;
        }
        #endregion

        #region [ Public methods ]
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
        public async Task<IActionResult> Edit(long id)
        {
            var movie = await _movieRepository.ReadAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var producers = await _producerRepository.ReadAsync(x => true);
            var model = _mapper.Map<EditMovieViewModel>(movie);
            model.Producers = new SelectList(producers, "Id", "FullName");
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEdit(EditMovieViewModel model)
        {
            var movie = await _movieRepository.ReadAsync(model.MovieId);
            
            //TODO Проверка на права
            //...

            //TODO Вынести в сервис
            if (model.Poster != null)
            {
                var posterFileName = await SavePoster(model.Poster);
                DeletePoster(movie.PosterFileName);    
                model.PosterFileName = posterFileName;
            }
            
            _mapper.Map(model, movie);
            _movieRepository.Update(movie);
            await _movieRepository.SaveAsync(); 
            
            return RedirectToAction($"Detail", new { id = movie.Id });
        }

        public IActionResult Delete(long id)
        {
            return View();
        }
        #endregion
        
        #region [ Private methods ]

        private async Task<string> SavePoster(IFormFile poster)
        {
            var posterFileExt = poster.ContentType.Split("/")[1];
            var posterFileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.{posterFileExt}";
            var posterFilePath = Path.Combine(_environment.WebRootPath, "img", posterFileName);
            
            await using var fileStream = new FileStream(posterFilePath, FileMode.Create);
            await poster.CopyToAsync(fileStream);

            return posterFileName;
        }

        private void DeletePoster(string posterFileName)
        {
            if (string.IsNullOrEmpty(posterFileName)) return;
            
            var posterFilePath = Path.Combine(_environment.WebRootPath, "img", posterFileName);
            if (System.IO.File.Exists(posterFilePath))
            {
                System.IO.File.Delete(posterFilePath);
            }
        }
        #endregion
    }
}