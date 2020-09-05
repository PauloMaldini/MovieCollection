using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Entities
{
    public class Movie : EntityCatalogBase<long>
    {
        [ForeignKey("Producer")]
        public long ProducerRefId { get; set; }
        public Producer Producer { get; set; }
        
        public int YearOfIssue { get; set; }
        
        public string Poster { get; set; }
    }

    public class MovieFilter : FilterBase
    {
        
    }

    public class MovieRepository : EFGenericRepository<Movie, MovieFilter, long>
    {
        public MovieRepository(MovieCollectionContext context) : base(context)
        {
            
        }
    }
}