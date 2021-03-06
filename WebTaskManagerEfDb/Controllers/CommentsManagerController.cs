﻿namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using ServiceLayer.Services;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Comments;
    using ViewModels.CommentsFilterVМ;
    public class CommentsManagerController : BaseController<CommentEntity, CommentsEditVM , CommentsListVM, CommentsFilterVM>
    {
        public override BaseService<CommentEntity> CreateService()
        {
            return new CommentsService();
        }

        public override ActionResult Redirect(CommentEntity entity)
        {
            return RedirectToAction("Details", "TasksManager", new { id = entity.TaskId });
        }

        public override void PopulateEntity(CommentEntity entity, CommentsEditVM model)
        {
            UsersRepository userRepo = new UsersRepository();
            UserEntity User = userRepo.GetAll().FirstOrDefault(u => u.Id == entity.CreatorId);

            entity.TaskId = model.TaskId;
            entity.CreatorId = AuthenticationManager.LoggedUser.Id;
            entity.Comment = model.Comment;
            entity.CreateDate = DateTime.Now;
        }

        public override void PopulateModel(CommentsEditVM model, CommentEntity entity)
        {
            UsersRepository userRepo = new UsersRepository();
            UserEntity User = userRepo.GetAll().FirstOrDefault(u => u.Id == entity.CreatorId);
                    
            int taskId = Convert.ToInt32(this.Request["taskID"]);
            model.Id = entity.Id;
            model.TaskId = taskId;
            model.CreatorId = entity.CreatorId;
            model.Comment = entity.Comment;
            model.CreateDate = entity.CreateDate;
        }
    }
}