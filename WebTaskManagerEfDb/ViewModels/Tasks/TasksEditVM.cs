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
        public string CreatorName { get; set; }
        [Required]
        public string ResponsibleUserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        //[Required]
        //public string Creator { get; set; }

        [Required(ErrorMessage = "Assignee is required!")]
        [Display(Name = "Assignee:")]
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