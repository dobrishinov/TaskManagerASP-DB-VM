namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ViewModels.Users;
    
    public class UsersManagerController : BaseController<UserEntity, UsersEditVM, UsersListVM>
    {
        public override BaseRepository<UserEntity> CreateRepository()
        {
            return new UsersRepository();
        }

        public override void PopulateEntity(UserEntity entity, UsersEditVM model)
        {
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.AdminStatus = model.AdminStatus;
        }

        public override void PopulateModel(UsersEditVM model, UserEntity entity)
        {
            model.Id = entity.Id;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.AdminStatus = entity.AdminStatus;
        }
    }
}