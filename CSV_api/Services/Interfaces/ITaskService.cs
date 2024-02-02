using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface ITaskService
    {
        public List<Models.Task> GetAll(int projectID);
        public Models.Task Create(Models.Task task);
        
        public void Delete(int taskID);
        List<Models.Task> GetTasksByCode(byte statusCode);
        public Models.Task GetOneTasksById(int id);
        public Models.Task Update(TaskDto task);
    }
}
