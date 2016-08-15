namespace WebTaskManagerEfDb.ViewModels
{
    using DataAccess.Entity;
    using System.Collections.Generic;

    public class BaseListVM<T, F>
        where T : BaseEntity 
        where F : BaseFilterVM<T>, new()
        
    {
        public BaseListVM()
        {
            this.Items = new List<T>();
            this.Filter = new F();
        }
        public List<T> Items { get; set; }

        public Pager Pager { get; set; }

        public F Filter { get; set; }
    }
}