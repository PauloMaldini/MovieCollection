using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieCollection.Web.Models.Movie
{
    public class EditMovieViewModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int YearIssue { get; set; }
        
        public long ProducerId { get; set; }
        
        public SelectList Producers { get; set; }
    }
}