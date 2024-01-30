using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        System.Threading.Tasks.Task Create(Project project);
        System.Threading.Tasks.Task Delete(Project project);
        System.Threading.Tasks.Task Update(Project project);
        System.Threading.Tasks.Task GetProjectDescription(int id);
        System.Threading.Tasks.Task UpdateProjectDescription(int id, string description);
        System.Threading.Tasks.Task AddUserToProject(int id, int userID);
        System.Threading.Tasks.Task DeleteUserFromProject(int id, int userID);
        System.Threading.Tasks.Task GetAllUsers(int id);

    }
}
