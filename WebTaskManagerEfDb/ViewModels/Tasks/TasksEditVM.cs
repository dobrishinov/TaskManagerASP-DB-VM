namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    using DataAccess.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    public class TasksEditVM : BaseEditVM
    {
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string CreatorName { get; set; }
        public string ResponsibleName { get; set; }
        [Required(ErrorMessage = "Assigned is required!")]
        [Display(Name = "Assigned to:")]
        public int ResponsibleUsers { get; set; }

        public List<UserEntity> Users;
        public IEnumerable<SelectListItem> UsersList
        {
            get
            {
                var allUsers = Users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Username
                });
                return allUsers;
            }
        }
    }
}