using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebTaskManagerEfDb.Models;
using WebTaskManagerEfDb.Tools;

namespace WebTaskManagerEfDb.ViewModels.WorkLog
{
    public class WorkLogFilterVM : BaseFilterVM<TimeEntity>
    {
        TimeRepository repo = new TimeRepository();

        public WorkLogFilterVM()
        {
            
        }

        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }

        [FilterProperty(DisplayName = "Content")]
        public string Content { get; set; }

        //[FilterProperty(DisplayName = "Time Created")]
        //public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        [FilterProperty(DisplayName = "Creator", DropDownTargetProperty = "CreatorId")]
        public List<ISelectItem> Creator { get; set; }

        public int ResponsibleId { get; set; }

        [FilterProperty(DisplayName = "Responsible", DropDownTargetProperty = "ResponsibleId")]
        public List<ISelectItem> Responsible { get; set; }

        public override Expression<Func<TimeEntity, bool>> BuildFilter()
        {
            return null;
        }
    }
}