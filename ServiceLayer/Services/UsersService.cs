namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class UsersService : BaseService<UserEntity>
    {
        protected override BaseRepository<UserEntity> GenerateService()
        {
            return new UsersRepository();
        }
    }
}
