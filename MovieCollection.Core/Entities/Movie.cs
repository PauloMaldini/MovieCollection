using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Entities
{
    public class Movie : EntityBase<long>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [ForeignKey("Producer")]
        public long ProducerRefId { get; set; }
        public Producer Producer { get; set; }
        
        public int YearOfIssue { get; set; }
        
        public string PosterFileName { get; set; }
    }

    public class MovieFilter : FilterBase
    {
        
    }

    public class MovieRepository : EFGenericRepository<Movie, MovieFilter, long>
    {
        public MovieRepository(MovieCollectionContext context) : base(context)
        {
            
        }

        protected override IQueryable<Movie> GetBaseQuery()
        {
            return DbSet.Include(x => x.Producer)
                .ThenInclude(x => x.Country);
        }
    }
}