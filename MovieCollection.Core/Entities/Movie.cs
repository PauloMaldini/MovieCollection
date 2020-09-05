using System.ComponentModel.DataAnnotations.Schema;
using MovieCollection.Core.Base;

namespace MovieCollection.Core.Entities
{
    public class Movie : EntityCatalogBase<long>
    {
        [ForeignKey("Producer")]
        public long ProducerRefId { get; set; }
        public Producer Producer { get; set; }
        
        public int YearOfIssuer { get; set; }
        
        public string Poster { get; set; }
    }
}