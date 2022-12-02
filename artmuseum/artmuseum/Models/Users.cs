namespace artmuseum.Models
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserDetails
    {
        public string exhibition { get; set; }
        public string date { get; set; }
        public string optional { get; set; }
        public string location { get; set; }
        public string time { get; set; }
        public string email { get; set; }
    }

    public class Result
    {
        public bool result { get; set; }
        public string message { get; set; }
    }
}
