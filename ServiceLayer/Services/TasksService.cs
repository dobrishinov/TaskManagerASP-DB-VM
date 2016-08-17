namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class TasksService : BaseService<TaskEntity>
    {
        protected override BaseRepository<TaskEntity> GenerateService()
        {
            return new TasksRepository();
        }
    }
}
