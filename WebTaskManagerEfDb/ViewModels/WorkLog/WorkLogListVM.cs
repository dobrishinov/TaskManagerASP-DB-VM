using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels.WorkLog
{
    public class WorkLogListVM : BaseListVM<TimeEntity, WorkLogFilterVM>
    {
    }
}