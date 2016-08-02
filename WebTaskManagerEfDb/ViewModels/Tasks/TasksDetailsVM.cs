namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    using System.ComponentModel.DataAnnotations;
  
    public class TaskDetailsVM : BaseEditVM
    {
        [Required]
        [Display(Name = "Creator Name")]
        public string CreatorName { get; set; }
        [Required]
        [Display(Name = "Responsible Users")]
        public string ResponsibleUserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}