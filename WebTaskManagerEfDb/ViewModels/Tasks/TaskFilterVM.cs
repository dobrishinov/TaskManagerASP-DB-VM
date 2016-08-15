using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebTaskManagerEfDb.Models;
using WebTaskManagerEfDb.Tools;

namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    public class TasksFilterVM : BaseFilterVM<TaskEntity>
    {
        UsersRepository repo = new UsersRepository();

        public TasksFilterVM()
        {
            //Responsible = SelectListHandler.Create<UserEntity>(repo.GetAll().ToList(), x => x.FirstName, x => x.Id.ToString(), ResponsibleId.ToString());
            //Creator = SelectListHandler.Create<UserEntity>(repo.GetAll().ToList(), x => x.FirstName, x => x.Id.ToString(), CreatorId.ToString());
        }

        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }

        [FilterProperty(DisplayName = "Content")]
        public string Content { get; set; }
        
        //[FilterProperty(DisplayName = "Creator", DropDownTargetProperty = "CreatorId")]
        //public List<ISelectItem> Creator { get; set; }
     
        public override Expression<Func<TaskEntity, bool>> BuildFilter()
        {
            return (p => ((p.Title.Contains(Title) || string.IsNullOrEmpty(Title))
            && ((p.Content.Contains(Content)) || string.IsNullOrEmpty(Content))));
        }
    }
}