using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll();
        System.Threading.Tasks.Task Create(Comment comment);
        System.Threading.Tasks.Task Delete(Comment comment);
        System.Threading.Tasks.Task Update(Comment comment);
    }
}
