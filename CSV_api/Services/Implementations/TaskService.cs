using AutoMapper;
using CSV_api.Data;
using CSV_api.Models;
using CSV_api.Services.Interfaces;

namespace CSV_api.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public readonly TestDbContext _db;
        public TaskService(TestDbContext db)
        {
            _db = db;
        }

        public Models.Task Create(Models.Task task)
        {
            _db.Tasks.AddAsync(task);
            _db.SaveChangesAsync();
            return task;
        }

        public void Delete(int taskID)
        {
            var taskToDelete = _db.Set<Models.Task>().FirstOrDefault(t => t.TaskId == taskID);
            if (taskToDelete == null)
            {
                throw new InvalidOperationException("There is no task with this ID");
            }
            _db.Set<Models.Task>().Remove(taskToDelete);
            _db.SaveChanges();
        }

        public List<Models.Task> GetAll(int projectID)
        {
            return _db.Tasks.Where(t => t.ProjectId.ToString() == projectID.ToString()).ToList();
        }

        public List<Models.Task> GetTasksByCode(byte statusCode)
        {
            return _db.Tasks.Where(t => t.Status == statusCode).ToList();
        }

        public Models.Task GetOneTasksById(int id)
        {
            return _db.Tasks.SingleOrDefault(p => p.TaskId == id);
        }

        public Models.Task Update(TaskDto task)
        {
            var taskToUpdate = _db.Tasks.Single<Models.Task>(t => t.TaskId == task.TaskId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Task, TaskDto>();
            });
            var mapper = new Mapper(config);
            var taskMapped = mapper.Map<Models.Task>(taskToUpdate);
            _db.Update(taskMapped);
            _db.SaveChanges();
            return taskMapped;
        }
    }
}
