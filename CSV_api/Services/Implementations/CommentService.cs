using CSV_api.Data;
using CSV_api.Models;
using CSV_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CSV_api.Services.Implementations
{
    public class CommentService : ICommentService
    {
        public readonly TestDbContext _db;
        public CommentService(TestDbContext db)
        {
            _db = db;
        }
        public Comment Create(Comment comment)
        {
            _db.Comments.AddAsync(comment);
            _db.SaveChangesAsync();
            return comment;
        }

        public void Delete(int id)
        {
            var commentToDelete = _db.Set<Comment>().FirstOrDefault(c => c.CommentId == id);
            if (commentToDelete == null)
            {
                throw new InvalidOperationException("There is no comment with this ID");
            }
            _db.Set<Comment>().Remove(commentToDelete);
            _db.SaveChanges();
        }

        public List<Comment> GetAll(int id)
        {
            return _db.Comments.Where(c => c.TaskId == id).ToList();
        }

        public Comment GetById(int id)
        {
            return _db.Comments.SingleOrDefault(c => c.CommentId == id);
        }

        public Comment Update(CommentDto comment)
        {
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var oldComment = _db.Comments.SingleOrDefault(p => p.CommentId == comment.CommentId);
            var newComment = new Comment() { CommentId = oldComment.CommentId, Text = comment.Text, CreationDate = comment.CreationDate, UpdateDate = comment.UpdateDate, TaskId = comment.TaskId };
            _db.Comments.Update(newComment);
            _db.SaveChangesAsync();
            return newComment;
        }
    }
}
