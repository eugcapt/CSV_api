using System.Data;

namespace CSV_api.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly updateDate { get; set;}

        public int TaskID {  get; set; }
        public Task? Task { get; set; }
    }
}
