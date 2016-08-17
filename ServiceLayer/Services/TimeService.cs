namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class TimeService : BaseService<TimeEntity>
    {
        protected override BaseRepository<TimeEntity> GenerateService()
        {
            return new TimeRepository();
        }
    }
}
