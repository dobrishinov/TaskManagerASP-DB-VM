using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebTaskManagerEfDb.Models;
using WebTaskManagerEfDb.Tools;

namespace WebTaskManagerEfDb.ViewModels.CommentsFilterVМ
{
    public class CommentsFilterVM : BaseFilterVM<CommentEntity>
    {
        CommentsRepository repo = new CommentsRepository();

        public CommentsFilterVM()
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

        public override Expression<Func<CommentEntity, bool>> BuildFilter()
        {
            return null;
        }
    }
}