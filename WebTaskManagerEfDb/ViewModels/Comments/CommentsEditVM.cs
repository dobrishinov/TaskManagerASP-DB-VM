namespace WebTaskManagerEfDb.ViewModels.Comments
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CommentsEditVM : BaseEditVM
    {
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string CreatorName { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public UserEntity User { get; set; }
    }
}