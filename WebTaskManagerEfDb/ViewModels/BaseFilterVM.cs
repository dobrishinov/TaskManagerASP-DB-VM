using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels
{
    public abstract class BaseFilterVM<T> where T : BaseEntity
    {
        public abstract Expression<Func<T, bool>> BuildFilter();

        public string Prefix { get { return "Filter."; } }

        public int? ActionId { get; set; }

        public Pager ParentPager { get; set; }
    }
}