namespace APIDemo.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }

        public DateTime EventDate { get; set; }
    }
}
