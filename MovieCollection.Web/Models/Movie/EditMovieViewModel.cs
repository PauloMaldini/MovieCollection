using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Models.Movie
{
    public class EditMovieViewModel  : MovieModelBase
    {
        public long ProducerId { get; set; }
        
        public SelectList Producers { get; set; }
    }
}