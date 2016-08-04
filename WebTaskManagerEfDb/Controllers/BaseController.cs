namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;

    public abstract class BaseController<T, EVM, IVM> : Controller
        // T - Entity
        where T : BaseEntity, new()
        //Edit - one element
        where EVM : BaseEditVM, new()
        //Index - all elements
        where IVM : BaseListVM<T>, new()
    {
        public BaseController()
        {
            this.Repository = CreateRepository();
        }
        
        private BaseRepository<T> Repository = null;
        public abstract BaseRepository<T> CreateRepository();
        public abstract void PopulateModel(EVM model, T entity);
        public abstract void PopulateEntity(T entity, EVM model);
        
         // GET: Base
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            IVM model = new IVM();
            model.Pager = new Pager();
            TryUpdateModel(model);

            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            //t => t.CreatorId == AuthenticationManager.LoggedUser.Id|| t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id
            
            model.Items = Repository.GetAll(null, model.Pager.CurrentPage, model.Pager.PageSize).ToList();
            model.Pager = new Pager(Repository.GetAll().Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            T entity = (id == null || id <= 0) ? new T() : Repository.GetById(id);
            EVM model = new EVM();
            PopulateModel(model, entity);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            EVM model = new EVM();
            TryUpdateModel(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            T entity = new T();
            PopulateEntity(entity, model);
            Repository.Save(entity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");


            T entity = Repository.GetById(id);
            Repository.Delete(entity);

            return RedirectToAction("Index");
        }
    }
}