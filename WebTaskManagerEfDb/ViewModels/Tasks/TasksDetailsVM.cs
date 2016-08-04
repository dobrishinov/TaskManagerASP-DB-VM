namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    using DataAccess.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TaskDetailsVM : BaseEditVM
    {
        [Required]
        [Display(Name = "Creator Name")]
        public string CreatorName { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public Pager PagerComments { get; set; }
        public Pager PagerWorkLog { get; set; }

        public List<CommentEntity> CommentsList { get; set; }
        public List<TimeEntity> WorkLogList { get; set; }

        public string ResponsibleName { get; set; }
    }
}