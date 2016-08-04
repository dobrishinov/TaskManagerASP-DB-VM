using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels.WorkLog
{
    public class WorkLogEditVM : BaseEditVM
    {
        public int TaskId { get; set; }
        public int EstimatedTime { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime CreateTime { get; set; }
    }
}