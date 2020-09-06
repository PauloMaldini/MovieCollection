namespace MovieCollection.Web.Models.Movie.Base
{
    public abstract class MovieModelBase 
    {
        public long MovieId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public long YearOfIssue { get; set; }
        
        
    }
}