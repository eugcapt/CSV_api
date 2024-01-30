namespace CSV_api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetTasks(int projectID);
        Task Create(int projectID);
        Task Update(int taskID, int projectID);
        Task Delete(int taskID, int projectID);
        Task<IEnumerable<Task>> GetTasks(int projectID, Constants.Constants.StatusCodes statusCode);
    }
}
