using AutoMapper;
using CSV_api.Data;
using CSV_api.Models;
using CSV_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace CSV_api.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public readonly TestDbContext _db;
        public ProjectService(TestDbContext db)
        {
            _db = db;
        }

        public User AddUserToProject(int userId, int projectId)
        {
            var userToAdd = _db.Set<User>().FirstOrDefault(u => u.UserId == userId);
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            userToAdd.ProjectId = projectId;
            _db.Users.Attach(userToAdd).Property(x => x.ProjectId).IsModified = true;
            _db.SaveChangesAsync();
            return userToAdd;

        }

        public Project Create(Project project)
        {
            _db.Projects.AddAsync(project);
            _db.SaveChangesAsync();
            return project;
        }

        public void Delete(int id)
        {
            var projectToDelete = _db.Set<Project>().FirstOrDefault(p => p.ProjectId == id);
            if (projectToDelete == null)
            {
                throw new InvalidOperationException("There is no project with this ID");
            }
            _db.Set<Project>().Remove(projectToDelete);
            _db.SaveChanges();
        }

        public void DeleteUserFromProject(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            return _db.Projects.ToList();
        }

        public List<User> GetAllUsers(int id)
        {
            return _db.Users.Where(u => u.ProjectId == id).ToList();
        }

        public ProjectDescriptionDto GetProjectDescription(int id)
        {
            var project = _db.Projects.SingleOrDefault(p => p.ProjectId == id);
            var projectDescription = new ProjectDescriptionDto
            (project.ProjectId, project.Description);

            return projectDescription;
        }

        public Project UpdateProjectDescription(int id, string description, ProjectDescriptionDto project)
        {
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var oldProject = _db.Projects.SingleOrDefault(p => p.ProjectId == id);
            var newProject = new Project() { ProjectId = oldProject.ProjectId, Description = description, CreationDate = oldProject.CreationDate, UpdateDate = oldProject.UpdateDate };
            _db.Projects.Attach(newProject).Property(x => x.Description).IsModified = true;
            _db.SaveChangesAsync();
            return newProject;
        }

        public Project GetById(int id)
        {
            return _db.Set<Project>().FirstOrDefault(p => p.ProjectId == id) ?? throw new InvalidOperationException("There is no user with this ID");
        }
    }
}
