namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ServiceLayer.Services;
    using ViewModels.Users;

    public class UsersManagerController : BaseController<UserEntity, UsersEditVM, UsersListVM, UsersFilterVM>
    {
        public override BaseService<UserEntity> CreateService()
        {
            return new UsersService();
        }

        public override void PopulateEntity(UserEntity entity, UsersEditVM model)
        {
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