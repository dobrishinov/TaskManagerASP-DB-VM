namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class StatusService : BaseService<StatusEntity>
    {
        protected override BaseRepository<StatusEntity> GenerateService()
        {
            return new StatusRepository();
        }
    }
}
