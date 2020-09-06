using System.Collections.Generic;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Models.Movie
{
    public class MovieModel : MovieModelBase
    {
        public string Producer { get; set; }
    }
    
    public class ListMovieViewModel
    {
        public long TotalCount { get; set; }
        
        public long FilteredCount { get; set; }
        
        public List<MovieModel> Movies { get; set; }
    }
}