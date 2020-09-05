using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Context;

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
        public ProducerRepository(MovieCollectionContext context) : base(context)
        {
            
        }
    }
}