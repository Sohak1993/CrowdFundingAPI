namespace CrowdFundingAPI.Models
{
    public class UserForm
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
    }
}
