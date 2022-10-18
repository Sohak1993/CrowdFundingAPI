﻿namespace CrowdFundingAPI.Models.User
{
    public class UserForm
    {
        public int Id { get; set; } 
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
        public int idRole { get; set; }
    }
}
