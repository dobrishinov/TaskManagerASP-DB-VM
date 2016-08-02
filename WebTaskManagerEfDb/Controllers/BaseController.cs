namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;
    using System;

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

        protected virtual void PopulateIndex(IVM model)
        {
            TryUpdateModel(model);
            BaseRepository<T> repo = CreateRepository();
            model.Items = repo.GetAll().ToList();
        }

        private BaseRepository<T> Repository = null;
        public abstract BaseRepository<T> CreateRepository();
        public abstract void PopulateModel(EVM model, T entity);
        public abstract void PopulateEntity(T entity, EVM model);

        protected abstract void BuildIndexModel(IVM model);


        // GET: Base
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            IVM model = new IVM();
            model.Pager = new Pager();
            TryUpdateModel(model);

            BuildIndexModel(model);
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

        public virtual ActionResult Details(int id)
        {
            EVM model = new EVM();
            T entity = new T();
            entity = CreateRepository().GetById(id);
            PopulateModel(model, entity);
            return View(model);
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