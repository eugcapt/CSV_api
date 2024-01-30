using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        System.Threading.Tasks.Task Create(User user);
        System.Threading.Tasks.Task Update(User user);
        System.Threading.Tasks.Task Delete(int id);
        Task<IEnumerable<User>> GetProjectUsers(Project project);
        System.Threading.Tasks.Task GetUserDescription(int id);
    }
}
