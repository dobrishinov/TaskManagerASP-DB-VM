namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Linq;
    using System.Web.Mvc;
    using WebTaskManagerEfDb.Controllers;
    using WebTaskManagerEfDb.ViewModels.Users;
    using System;
    using ViewModels;
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

        protected override void BuildIndexModel(UsersListVM model)
        {
            UsersRepository repo = new UsersRepository();

            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();

            model.Items = repo.GetAll(null, model.Pager.CurrentPage, model.Pager.PageSize).ToList();
            model.Pager = new Pager(repo.GetAll().Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);

        }



        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (AuthenticationManager.LoggedUser == null)
        //        return RedirectToAction("Login", "Home");

        //    UsersRepository usersRepository = new UsersRepository();

        //    UserEntity user = null;
        //    if (id == null)
        //        user = new UserEntity();
        //    else
        //        user = usersRepository.GetById(id.Value);

        //    UsersEditVM model = new UsersEditVM();
        //    model.Id = user.Id;
        //    model.FirstName = user.FirstName;
        //    model.LastName = user.LastName;
        //    model.Username = user.Username;
        //    model.Password = user.Password;
        //    model.AdminStatus = user.AdminStatus;

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(UsersEditVM model)
        //{
        //    if (AuthenticationManager.LoggedUser == null)
        //        return RedirectToAction("Login", "Home");

        //    UsersRepository usersRepository = new UsersRepository();
        //    UserEntity entity = new UserEntity();
        //    entity.Id = model.Id;
        //    entity.FirstName = model.FirstName;
        //    entity.LastName = model.LastName;
        //    entity.Username = model.Username;
        //    entity.Password = model.Password;
        //    entity.AdminStatus = model.AdminStatus;
        //    usersRepository.Save(entity);

        //    return RedirectToAction("Index", "UsersManager");
        //}

        //public ActionResult Delete(int id)
        //{
        //    if (AuthenticationManager.LoggedUser == null)
        //        return RedirectToAction("Login", "Home");

        //    UsersRepository usersRepository = new UsersRepository();
        //    UserEntity user = usersRepository.GetById(id);
        //    usersRepository.Delete(user);

        //    return RedirectToAction("Index", "UsersManager");
        //}
    }
}