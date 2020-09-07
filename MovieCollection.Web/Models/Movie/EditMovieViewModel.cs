using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Models.Movie
{
    public class EditMovieViewModel  : MovieModelBase, IValidatableObject
    {
        public string PosterFileName { get; set; }
        
        [Display(Name = "Режиссер")]
        [Required]
        public long ProducerId { get; set; }
        public SelectList Producers { get; set; }
        
        public IFormFile Poster { get; set; }

        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var valResult in base.Validate(validationContext))
            {
                yield return valResult;
            }
           
            if (Poster != null && Poster.Length > 1048576)
            {
                yield return new ValidationResult("Недопустим размер постера более 100Кб");
            }
        }
    }
}