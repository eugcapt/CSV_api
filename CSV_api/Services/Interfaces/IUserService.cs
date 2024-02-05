using CSV_api.Models;

namespace CSV_api.Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User Create(User user);
        public User Update(User user);
        public void Delete(int id);
        public List<User> GetProjectUsers(int projectID);
        public UserDescriptionDto GetUserDescription(int id);
    }
}
