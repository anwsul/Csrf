namespace MyBank.Models
{
    public class User
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        override
        public string ToString()
        {
            return $"username={Username},password={Password}";
        }
    }

}
