namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;
    using System.Linq.Expressions;
    using System;
    using ServiceLayer.Services;
    public abstract class BaseController<T, EVM, IVM, F> : Controller
        // T - Entity
        where T : BaseEntity, new()
        //Edit - one element
        where EVM : BaseEditVM, new()
        //Index - all elements
        where IVM : BaseListVM<T, F>, new()
        // Filter
        where F : BaseFilterVM<T>, new()
    {
        public BaseController()
        {
            this.Service = CreateService();
        }
        
        private BaseService<T> Service = null;
        public abstract BaseService<T> CreateService();
        public abstract void PopulateModel(EVM model, T entity);
        public abstract void PopulateEntity(T entity, EVM model);
        protected Expression<Func<T, bool>> Filter { get; set; }

        public virtual ActionResult Redirect(T entity)
        {
            return RedirectToAction("Index");
        }

        protected virtual Expression<Func<T, bool>> CreateFilter()
        {
            return null;
        }

        // GET: Base
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            IVM model = new IVM();
            model.Pager = new Pager();
            model.Filter = new F();
            TryUpdateModel(model);

            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            //t => t.CreatorId == AuthenticationManager.LoggedUser.Id|| t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id

            model.Filter.ParentPager = model.Pager;

            model.Items = Service.GetAll(model.Filter.BuildFilter(), model.Pager.CurrentPage, model.Pager.PageSize).ToList();
            model.Pager = new Pager(Service.GetAll(model.Filter.BuildFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            T entity = (id == null || id <= 0) ? new T() : Service.GetById(id);
            EVM model = new EVM();
            PopulateModel(model, entity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            EVM model = new EVM();
            TryUpdateModel(model);
          
           
            T entity = (model.Id <= 0) ? new T() : Service.GetById(model.Id);
            PopulateEntity(entity, model);
            Service.Save(entity);

             return Redirect(entity);
            
        }

        public ActionResult Delete(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");


            T entity = Service.GetById(id);
            Service.Delete(entity);

            return Redirect(entity);
        }
    }
}