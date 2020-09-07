using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieCollection.Core.Entities;
using MovieCollection.Core.Interface;
using MovieCollection.Web.Models;
using MovieCollection.Web.Models.Movie;

namespace MovieCollection.Web.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        #region [ Members ]
        private const long PageSize = 7;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IRepository<Movie, MovieFilter, long> _movieRepository;
        private readonly IRepository<Producer, ProducerFilter, long> _producerRepository;
        #endregion

        #region [ Contructors ]
        public MovieController(IMapper mapper,
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
        public async Task<IActionResult> Index(long pageIndex = 0, long pageSize = PageSize)
        {
            var movies = await _movieRepository.ReadAsync(
                new MovieFilter { PageIndex = pageIndex, PageSize = pageSize });
            var model = _mapper.Map<ListMovieViewModel>(movies);
            model.PageIndex = pageIndex;
            model.PageSize = pageSize;
            
            return View(model);
        }

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
        public async Task<IActionResult> Create()
        {
            var producers = await _producerRepository.ReadAsync(x => true);
            return View(await FillEditMovieViewModelLists());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EditMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await FillEditMovieViewModelLists(model));
            }
            
            var movie = _mapper.Map<Movie>(model);
            
            //TODO Здесь что-то вроде распределенной транзакции, поэтому нужен дополнительный функционал поддержания целостности данных
            //TODO Нужно вынести из контроллера в Core
            var posterFileName = await SavePoster(model.Poster);
            movie.PosterFileName = posterFileName;
            movie.Author = User.Identity.Name;
            _movieRepository.Create(movie);
            await _movieRepository.SaveAsync(); 
            
            return RedirectToAction($"Detail", new { id = movie.Id });
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var movie = await _movieRepository.ReadAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            
            if (movie.Author != User.Identity.Name)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            
            var model = await FillEditMovieViewModelLists(_mapper.Map<EditMovieViewModel>(movie));
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await FillEditMovieViewModelLists(model));
            }

            model.Author = User.Identity.Name;
            
            var movie = _mapper.Map(model, await _movieRepository.ReadAsync(model.MovieId));
            if (movie.Author != User.Identity.Name)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            //TODO Здесь что-то вроде распределенной транзакции, поэтому нужен дополнительный функционал поддержания целостности данных
            //TODO Нужно вынести из контроллера в Core
            if (model.Poster != null)
            {
                var posterFileName = await SavePoster(model.Poster);
                DeletePoster(movie.PosterFileName);    
                movie.PosterFileName = posterFileName;
            }
            _movieRepository.Update(movie);
            await _movieRepository.SaveAsync(); 
            
            return RedirectToAction($"Detail", new { id = movie.Id });
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

        private async Task<EditMovieViewModel> FillEditMovieViewModelLists(EditMovieViewModel model = null)
        {
            model ??= new EditMovieViewModel();
            var producers = await _producerRepository.ReadAsync(x => true);
            model.Producers = new SelectList(producers, "Id", "FullName");

            return model;
        }
        #endregion
    }
}