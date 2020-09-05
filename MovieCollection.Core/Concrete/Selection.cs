using System.Collections.Generic;

 namespace MovieCollection.Core.Concrete
{
    public class Selection<TItem>
    {
        //Набор данных с учетом фильтра и пагинации
        public List<TItem> Items { get; set; }

        //Кол-во записей без учета фильтра и пагинации
        public long TotalCount { get; set; }
        
        //Кол-во записей без учета пагинации, но с учетом фильтра
        public long FilteredCount { get; set; }
    }
}
