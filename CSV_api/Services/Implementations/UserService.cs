using CSV_api.Data;
using CSV_api.Models;
using CSV_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Entity;

namespace CSV_api.Services.Implementations
{
    public class UserService : IUserService
    {
        public readonly TestDbContext _db;
        public UserService(TestDbContext db)
        {
            _db = db;
        }

        public User Create(User user)
        {
            _db.Users.AddAsync(user);
            _db.SaveChangesAsync();
            return user;
        }

        public void Delete(int id)
        {
            var userToDelete = _db.Set<User>().FirstOrDefault(u => u.UserId == id);
            if (userToDelete == null)
            {
                throw new InvalidOperationException("There is no user with this ID");
            }
            _db.Set<User>().Remove(userToDelete);
            _db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList() ?? throw new Exception();
        }

        public User GetById(int id)
        {
            return _db.Set<User>().FirstOrDefault(u => u.UserId == id) ?? throw new InvalidOperationException("There is no user with this ID");
        }

        public List<User> GetProjectUsers(int projectID)
        {

            return _db.Users.Where(u => u.ProjectId == projectID).ToList() ?? throw new Exception();
        }

        public UserDescriptionDto GetUserDescription(int id)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserId == id) ?? throw new Exception();
            var userDescription = new UserDescriptionDto
            (user.Name,user.Surname,user.Email,user.RegDate);
            
            return userDescription;

        }

        public User Update(User user)
        {
            var userToUpdate = _db.Set<User>().FirstOrDefault(u => u.UserId == user.UserId);
            if (userToUpdate != null)
            { userToUpdate = user; }
            _db.Update(userToUpdate) ;
            _db.SaveChanges();
            return userToUpdate ?? throw new Exception();
        }
    }
}
