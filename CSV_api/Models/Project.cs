
namespace CSV_api.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
        public required DateOnly CreatedDate { get; set; }
        public DateOnly? UpdateDate { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Task> Task { get; set; } = new List<Task>();

    }
}
