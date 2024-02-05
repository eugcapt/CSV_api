//using CSV_api.Models;

using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface IProjectService
    {
        public List<Project> GetAll();
        public Project GetById(int id);
        public Project Create(Project project);
        public void Delete(int id);
        public ProjectDescriptionDto GetProjectDescription(int id);
        public Project UpdateProjectDescription(int id, string description, ProjectDescriptionDto project);
        public User AddUserToProject(int userId, int projectId);
        public void DeleteUserFromProject(int userID);
        public List<User> GetAllUsers(int id);

    }
}
