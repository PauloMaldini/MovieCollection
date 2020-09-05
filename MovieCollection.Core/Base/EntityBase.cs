using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieCollection.Core.Interface;

namespace MovieCollection.Core.Base
{
    public abstract class EntityBase<TKey> : IEntity<TKey> 
    {
        [Key, Column(Order = 0)]       
        public TKey Id { get; set; }
        
        public string Author { get; set; }

        public bool Deleted { get; set; }

        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
    }
}