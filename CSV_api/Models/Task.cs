using CSV_api.Services.Constants;
namespace CSV_api.Models
{
   
    public class Task
    {
        public int TaskID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Constants.StatusCodes Status { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly UpdateDate { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }  

        public IEnumerable<Comment> Comments { get; set; } = Enumerable.Empty<Comment>();
    }
}
