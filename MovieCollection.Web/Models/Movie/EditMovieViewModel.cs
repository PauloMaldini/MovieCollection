using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Models.Movie
{
    public class EditMovieViewModel  : MovieModelBase
    {
        public string PosterFileName { get; set; }
        
        [Display(Name = "Режиссер")]
        public long ProducerId { get; set; }
        public SelectList Producers { get; set; }
    }
}