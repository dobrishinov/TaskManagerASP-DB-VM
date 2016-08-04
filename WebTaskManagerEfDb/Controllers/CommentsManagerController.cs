namespace WebTaskManagerEfDb.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using ViewModels.Comments;

    public class CommentsManagerController : BaseController<CommentEntity, CommentsEditVM , CommentsListVM>
    {
        public override BaseRepository<CommentEntity> CreateRepository()
        {
            return new CommentsRepository();
        }

        public override void PopulateEntity(CommentEntity entity, CommentsEditVM model)
        {
            entity.Id = model.Id;
            entity.TaskId = model.TaskId;
            entity.CreatorId = model.CreatorId;
            entity.Comment = model.Comment;
            entity.CreateDate = model.CreateDate;
        }

        public override void PopulateModel(CommentsEditVM model, CommentEntity entity)
        {
            model.Id = entity.Id;
            model.TaskId = entity.TaskId;
            model.CreatorId = entity.CreatorId;
            model.Comment = entity.Comment;
            model.CreateDate = entity.CreateDate;
        }
    }
}