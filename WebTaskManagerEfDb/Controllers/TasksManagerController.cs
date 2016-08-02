namespace WebTaskManagerEfDb.Controllers
{
    using System;
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ViewModels.Tasks;
    using Models;
    using ViewModels;
    using System.Linq;
    using System.Web.Mvc;

    public class TasksManagerController : BaseController<TaskEntity, TasksEditVM, TasksListVM>
    {
        public override BaseRepository<TaskEntity> CreateRepository()
        {
            return new TasksRepository();
        }

        protected override void PopulateIndex(TasksListVM model)
        {
            //model.Filter = new TasksFilterVM();
            TryUpdateModel(model);
            TasksRepository repo = new TasksRepository();
            model.Items = repo.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id
                                  || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id).ToList();

            model.Items = repo.GetAll(/*model.Filter.BuildFilter()*/).ToList();
        }

        public override void PopulateEntity(TaskEntity entity, TasksEditVM model)
        {

            entity.Id = model.Id;
            entity.CreatorId = model.CreatorId;
            entity.CreatorName = model.CreatorName;
            entity.ResponsibleUsers = model.ResponsibleUsers;
            entity.ResponsibleUserName = model.ResponsibleUserName;
            entity.Title = model.Title;
            entity.Content = model.Content;

            UsersRepository userRepo = new UsersRepository();
            model.Users = userRepo.GetAll().ToList();
        }

        public override void PopulateModel(TasksEditVM model, TaskEntity entity)
        {

            model.Id = entity.Id;
            model.CreatorId = AuthenticationManager.LoggedUser.Id;
            model.CreatorName = AuthenticationManager.LoggedUser.Username;
            model.ResponsibleUsers = entity.ResponsibleUsers;
            model.ResponsibleUserName = entity.ResponsibleUserName;
            model.Title = entity.Title;
            model.Content = entity.Content;

            UsersRepository userRepo = new UsersRepository();
            model.Users = userRepo.GetAll().ToList();
        }

        protected override void BuildIndexModel(TasksListVM model)
        {
            TasksRepository repo = new TasksRepository();
            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();

            model.Items = repo.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id
                                  || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id, model.Pager.CurrentPage, model.Pager.PageSize).ToList();
            model.Pager = new Pager(repo.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id
                                  || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
        }

        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }
        //    public ActionResult Index()
        //    {
        //        if (AuthenticationManager.LoggedUser == null)
        //            return RedirectToAction("Login", "Home");

        //        TasksRepository TasksRepository = new TasksRepository();
        //        TasksListVM model = new TasksListVM();
        //        model.Items = TasksRepository.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id).ToList();

        //        return View(model);
        //    }
        //    [HttpGet]
        //    public ActionResult Edit(int? id)
        //    {
        //        if (AuthenticationManager.LoggedUser == null)
        //            return RedirectToAction("Login", "Home");

        //        TasksRepository tasksRepository = new TasksRepository();

        //        TaskEntity task = null;
        //        if (id == null)
        //            task = new TaskEntity();
        //        else
        //            task = tasksRepository.GetById(id.Value);

        //        TasksEditVM model = new TasksEditVM();
        //        model.Id = task.Id;
        //        model.CreatorId = AuthenticationManager.LoggedUser.Id;
        //        model.CreatorName = AuthenticationManager.LoggedUser.Username;
        //        model.ResponsibleUsers = task.ResponsibleUsers;
        //        model.ResponsibleUserName = task.ResponsibleUserName;
        //        model.Title = task.Title;
        //        model.Content = task.Content;

        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult Edit(TasksEditVM model)
        //    {
        //        if (AuthenticationManager.LoggedUser == null)
        //            return RedirectToAction("Login", "Home");

        //        TasksRepository tasksRepository = new TasksRepository();
        //        TaskEntity entity = new TaskEntity();
        //        entity.Id = model.Id;
        //        entity.CreatorId = model.CreatorId;
        //        entity.CreatorName = model.CreatorName;
        //        entity.ResponsibleUsers = model.ResponsibleUsers;
        //        entity.ResponsibleUserName = model.ResponsibleUserName;
        //        entity.Title = model.Title;
        //        entity.Content = model.Content;

        //        tasksRepository.Save(entity);

        //        return RedirectToAction("Index", "TasksManager");
        //    }

        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        TasksRepository userRepo = new TasksRepository();
        //        TaskEntity user = userRepo.GetById(id.Value);

        //        if (user == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        TaskDetailsVM model = new TaskDetailsVM()
        //        {
        //            Id = user.Id,
        //            CreatorName = user.CreatorName,   
        //            ResponsibleUserName = user.ResponsibleUserName,
        //            Title = user.Title,
        //            Content = user.Content,
        //        };

        //        return View(model);
        //    }

        //    public ActionResult Delete(int id)
        //    {
        //        if (AuthenticationManager.LoggedUser == null)
        //            return RedirectToAction("Login", "Home");

        //        TasksRepository tasksRepository = new TasksRepository();
        //        TaskEntity user = tasksRepository.GetById(id);
        //        tasksRepository.Delete(user);

        //        return RedirectToAction("Index", "TasksManager");
        //    }

    }
}