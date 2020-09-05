using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Entities
{
    public class Country : EntityCatalogBase<long>
    {
        
    }

    public class CountryFilter : FilterBase
    {
        
    }

    public class CountryRepository : EFGenericRepository<Country, CountryFilter, long>
    {
        public CountryRepository(MovieCollectionContext context) : base(context)
        {
            
        }
    }
}