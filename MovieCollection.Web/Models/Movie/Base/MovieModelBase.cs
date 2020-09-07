using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Web.Models.Movie.Base
{
    public abstract class MovieModelBase
    {
        public long MovieId { get; set; }
        
        [Display(Name = "Наименование")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }
        
        [Display(Name = "Год выпуска")]
        [Required]
        public long YearOfIssue { get; set; }
        
        [Display(Name = "Владелец")]
        public string Author { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var minYear = 1900;
            var maxYear = DateTime.Now.Year + 3;
            if (YearOfIssue < minYear || YearOfIssue > maxYear)
            {
                yield return new ValidationResult($"Год выпуска должен быть в интервале от {minYear} до {maxYear}");
            }
        }
    }
}