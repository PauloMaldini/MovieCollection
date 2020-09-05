namespace MovieCollection.Core.Interface
{
    public interface IPagination
    {
        long? PageIndex { get; set; }

        long? PageSize { get; set; }
    }

    public interface IFilter : IPagination
    {
        string OrderBy { get; set; }
    }
}
