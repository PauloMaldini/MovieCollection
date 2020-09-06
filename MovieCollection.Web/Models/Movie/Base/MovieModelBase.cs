using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Web.Models.Movie.Base
{
    public abstract class MovieModelBase 
    {
        public long MovieId { get; set; }
        
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Год выпуска")]
        public long YearOfIssue { get; set; }
    }
}