namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    using System.ComponentModel.DataAnnotations;
    
    public class TasksEditVM : BaseEditVM
    {
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public int ResponsibleUsers { get; set; }
        [Required]
        public string CreatorName { get; set; }
        [Required]
        public string ResponsibleUserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Creator { get; set; }
    }
}