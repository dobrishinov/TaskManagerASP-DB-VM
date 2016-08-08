namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System;
    using System.Web.Mvc;
    using ViewModels.Comments;

    public class CommentsManagerController : BaseController<CommentEntity, CommentsEditVM , CommentsListVM>
    {
        public override BaseRepository<CommentEntity> CreateRepository()
        {
            return new CommentsRepository();
        }

        public override ActionResult Redirect(CommentEntity entity)
        {
            return RedirectToAction("Details", "TasksManager", new { id = entity.TaskId });
        }

        public override void PopulateEntity(CommentEntity entity, CommentsEditVM model)
        {
            entity.TaskId = model.TaskId;
            entity.CreatorId = AuthenticationManager.LoggedUser.Id;
            entity.Comment = model.Comment;
            entity.CreateDate = DateTime.Now;
        }

        public override void PopulateModel(CommentsEditVM model, CommentEntity entity)
        {

            int taskId = Convert.ToInt32(this.Request["taskID"]);
            model.Id = entity.Id;
            model.TaskId = taskId;
            model.CreatorId = entity.CreatorId;
            model.Comment = entity.Comment;
            model.CreateDate = entity.CreateDate;
        }
    }
}