namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ViewModels.Tasks;
    using Models;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;
    public class TasksManagerController : BaseController<TaskEntity, TasksEditVM, TasksListVM>
    {
        public override BaseRepository<TaskEntity> CreateRepository()
        {
            return new TasksRepository();
        }

        public override void PopulateEntity(TaskEntity entity, TasksEditVM model)
        {
            entity.CreatorId = AuthenticationManager.LoggedUser.Id;
            entity.ResponsibleUsers = model.ResponsibleUsers;
            entity.Title = model.Title;
            entity.Content = model.Content;
            if (entity.Id<=0)
            {
                entity.CreatorId = AuthenticationManager.LoggedUser.Id;

            }
            else
            {
                entity.CreatorId = model.CreatorId;
            }

            UsersRepository userRepo = new UsersRepository();
            model.Users = userRepo.GetAll().ToList();
        }

        public override void PopulateModel(TasksEditVM model, TaskEntity entity)
        {
            UsersRepository repo = new UsersRepository();
            if (entity.CreatorId > 0 && entity.ResponsibleUsers > 0)
            {
                model.CreatorName = repo.GetAll(u => u.Id == entity.CreatorId).FirstOrDefault().Username;
                model.ResponsibleName = repo.GetAll(t => t.Id == entity.ResponsibleUsers).FirstOrDefault().Username;
            }

            model.Id = entity.Id;
            model.CreatorId = entity.CreatorId;
            model.ResponsibleUsers = entity.ResponsibleUsers;
            model.Title = entity.Title;
            model.Content = entity.Content;
            UsersRepository userRepo = new UsersRepository();
            model.Users = userRepo.GetAll().ToList();
        }
        
        public ActionResult Details(int id)
        {

            //all object that we want to map with tryupdatemodel
            TaskDetailsVM model = new TaskDetailsVM();
            model.PagerComments = new Pager();
            model.PagerWorkLog = new Pager();
            TryUpdateModel(model);
            
            //All repositories
            TasksRepository taskRepo = new TasksRepository();
            UsersRepository userRepo = new UsersRepository();
            TimeRepository timeRepo =  new TimeRepository();
            CommentsRepository commentRepo = new CommentsRepository();

            //get the specific name that we show (inache kazano da ne e int kakto vika Bai Georgi)
            TaskEntity task = (id <= 0) ? new TaskEntity() :taskRepo.GetById(id);
            UserEntity creatorUser = null;
            UserEntity responsibleUser = null;
            if (id==0)
            {
                 creatorUser = userRepo.GetById(AuthenticationManager.LoggedUser.Id);
                responsibleUser = userRepo.GetById(AuthenticationManager.LoggedUser.Id);
            }
            else
            {
                 creatorUser = userRepo.GetById(task.CreatorId);
                     responsibleUser = userRepo.GetById(task.ResponsibleUsers);
            }

            //fill the model
            model.Id = task.Id;
            model.CreatorName = creatorUser.FirstName +" "+ creatorUser.LastName;
            model.ResponsibleName = responsibleUser.FirstName + " " + responsibleUser.LastName;
            model.Content = task.Content;
            model.Title = task.Title;

            //fill the model's list that give to the partialsViews
            model.CommentsList = commentRepo.GetAll(c => c.TaskId == model.Id, model.PagerComments.CurrentPage, model.PagerComments.PageSize).ToList();
            model.WorkLogList = timeRepo.GetAll(w => w.TaskId == model.Id, model.PagerWorkLog.CurrentPage, model.PagerWorkLog.PageSize).ToList();
           
            //fill the pager with the specific data //Yanka beshe tuk :D :D :D kaza da go iztriq ama nqma da e

            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            
            model.PagerComments = new Pager(commentRepo.GetAll().Count(c => c.TaskId == model.Id), model.PagerComments.CurrentPage, "PagerComments.", action, controller, model.PagerComments.PageSize);

            model.PagerWorkLog = new Pager(timeRepo.GetAll().Count(l => l.TaskId == model.Id), model.PagerWorkLog.CurrentPage, "PagerWorkLog.", action, controller, model.PagerWorkLog.PageSize);

            return View(model);
        }
    }
}