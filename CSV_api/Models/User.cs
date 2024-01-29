namespace CSV_api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public required string Email { get; set; }
        public required DateOnly RegDate { get; set; }
        public DateOnly? UpdateDate { get; set; }

        //foreign table navigation
        public int ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
