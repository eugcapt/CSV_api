using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface ICommentService
    {
        public List<Comment> GetAll(int id);
        public Comment GetById(int id);
        public Comment Create(CommentDto comment);
        public void Delete(int id);
        public Comment Update(CommentDto comment);
    }
}
