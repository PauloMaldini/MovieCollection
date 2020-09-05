using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;

namespace MovieCollection.Core.Entities
{
    public class Producer : EntityCatalogBase<long>
    {
        
    }
    
    public class MovieProducer : FilterBase
    {
        
    }

    public class ProducerRepository : EFGenericRepository<Movie, MovieFilter, long>
    {
        public ProducerRepository(DbContext context) : base(context)
        {
            
        }
    }
}