namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class CommentsService : BaseService<CommentEntity>
    {
        protected override BaseRepository<CommentEntity> GenerateService()
        {
            return new CommentsRepository();
        }
    }
}
