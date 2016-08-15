using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTaskManagerEfDb.ViewModels.CommentsFilterVМ;

namespace WebTaskManagerEfDb.ViewModels.Comments
{
    public class CommentsListVM : BaseListVM<CommentEntity, CommentsFilterVM>
    {
    }
}