using System.Collections.Generic;

namespace MovieCollection.Core.Concrete
{
    public class PropertyMapping
    {
        public string SourcePropertyName { get; set; }
        
        public List<string> DestinationPropertyNames { get; set; }
        
        public bool Revert { get; set; }
    }
}