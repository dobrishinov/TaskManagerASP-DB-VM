using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels.Comments
{
    public class CommentsEditVM : BaseEditVM
    {
        public int CreatorId { get; set; }
        public int TaskId { get; set; }
        public string CreatorName { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}