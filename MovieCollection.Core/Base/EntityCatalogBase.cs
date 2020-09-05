namespace MovieCollection.Core.Base
{
    public abstract class EntityCatalogBase<T> : EntityBase<T>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}