namespace WebTaskManagerEfDb.ViewModels.Tasks
{
    using DataAccess.Entity;
    using System;
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

        [Display(Name = "Last Edit Time")]
        public DateTime CreateTime { get; set; }

        public Pager PagerComments { get; set; }
        public Pager PagerWorkLog { get; set; }

        public List<CommentEntity> CommentsList { get; set; }
        public List<TimeEntity> WorkLogList { get; set; }

        public string ResponsibleName { get; set; }
    }
}