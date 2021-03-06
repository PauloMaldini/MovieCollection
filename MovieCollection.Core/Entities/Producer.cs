using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Base;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Entities
{
    public class Producer : EntityBase<long>
    {
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        [ForeignKey("Country")]
        public long CountryRefId { get; set; }
        public Country Country { get; set; }

        public string FullName => $"{FirstName}{" " + MiddleName}{" " + LastName}";
    }
    
    public class ProducerFilter : FilterBase
    {
        
    }

    public class ProducerRepository : EFGenericRepository<Producer, ProducerFilter, long>
    {
        public ProducerRepository(MovieCollectionContext context) : base(context)
        {
            
        }
    }
}