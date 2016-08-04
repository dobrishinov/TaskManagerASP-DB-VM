namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using ViewModels.WorkLog;
    using DataAccess.Repository;

    public class WorkLogManagerController : BaseController<TimeEntity, WorkLogEditVM, WorkLogListVM>
    {
        public override BaseRepository<TimeEntity> CreateRepository()
        {
            return new TimeRepository();
        }

        public override void PopulateEntity(TimeEntity entity, WorkLogEditVM model)
        {
            entity.Id = model.Id;
            entity.TaskId = model.TaskId;
            entity.LastChange = model.LastChange;
            entity.CreateTime = model.CreateTime;
            entity.EstimatedTime = model.EstimatedTime;
        }

        public override void PopulateModel(WorkLogEditVM model, TimeEntity entity)
        {
            model.Id = entity.Id;
            model.TaskId = entity.TaskId;
            model.LastChange = entity.LastChange;
            model.CreateTime = entity.CreateTime;
            model.EstimatedTime = entity.EstimatedTime;
        }
        
    }
}