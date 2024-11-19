using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class Users
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
