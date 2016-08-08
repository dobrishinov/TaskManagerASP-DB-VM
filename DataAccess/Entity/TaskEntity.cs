namespace DataAccess.Entity
{
    using System;

    public class TaskEntity : BaseEntity
    {
        public int CreatorId { get; set; }
        public int ResponsibleUsers { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
