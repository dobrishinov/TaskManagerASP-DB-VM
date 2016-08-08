namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using ViewModels.WorkLog;
    using DataAccess.Repository;
    using System.Web.Mvc;
    using System;
    public class WorkLogManagerController : BaseController<TimeEntity, WorkLogEditVM, WorkLogListVM>
    {
        public override BaseRepository<TimeEntity> CreateRepository()
        {
            return new TimeRepository();
        }

        public override ActionResult Redirect(TimeEntity entity)
        {
            return RedirectToAction("Details", "TasksManager", new { id = entity.TaskId });
        }

        public override void PopulateEntity(TimeEntity entity, WorkLogEditVM model)
        {
            entity.Id = model.Id;
            entity.TaskId = model.TaskId;
            entity.LastChange = DateTime.Now;
            entity.CreateTime = DateTime.Now;
            entity.EstimatedTime = model.EstimatedTime;
        }

        public override void PopulateModel(WorkLogEditVM model, TimeEntity entity)
        {

            int taskId = Convert.ToInt32(this.Request["taskID"]);
            model.Id = entity.Id;
            model.TaskId = taskId;
            model.LastChange = entity.LastChange;
            model.CreateTime = entity.CreateTime;
            model.EstimatedTime = entity.EstimatedTime;
        }
        
    }
}