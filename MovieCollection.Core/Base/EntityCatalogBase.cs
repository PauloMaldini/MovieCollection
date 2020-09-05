namespace MovieCollection.Core.Base
{
    public abstract class EntityCatalogBase<T> : EntityBase<T>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Sort { get; set; }
    }
}