namespace WebTaskManagerEfDb.ViewModels
{
    using System.Collections.Generic;

    public class BaseListVM<T> 
    {
        public List<T> Items { get; set; }

        public Pager  Pager { get; set; }
    }
}