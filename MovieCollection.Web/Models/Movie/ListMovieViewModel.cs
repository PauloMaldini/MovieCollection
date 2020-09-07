using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Models.Movie
{
    public class MovieModel : MovieModelBase
    {
        [Display(Name = "Режиссер")]
        public string Producer { get; set; }
    }
    
    public class ListMovieViewModel
    {
        public long TotalCount { get; set; }
        
        public long FilteredCount { get; set; }
        
        public long PageIndex { get; set; }
        
        public long PageSize { get; set; }
        
        public List<MovieModel> Movies { get; set; }
    }
}