using System.Collections.Generic;

namespace MovieCollection.Web.Models.Movie
{
    public class MovieModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public long YearOfIssue { get; set; }
        
        public string Producer { get; set; }
    }
    
    public class ListMovieViewModel
    {
        public long TotalCount { get; set; }
        
        public long FilteredCount { get; set; }
        
        public List<MovieModel> Movies { get; set; }
    }
}