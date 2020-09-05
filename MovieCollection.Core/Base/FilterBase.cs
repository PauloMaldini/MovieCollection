using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Core.Base
{
    public abstract class FilterBase
    {
        [Range(0, long.MaxValue)]
        public long? PageIndex { get; set; }

        [Range(1, long.MaxValue)]
        public long? PageSize { get; set; }
        
        public string OrderBy { get; set; }
    }
}
