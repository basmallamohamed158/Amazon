using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [MaxLength(50)]
        public string User_Name { get; set; }
        [Required]
        public string User_Gmail { get; set; }
        [MinLength(8)]
        public string User_Password { get; set; }
        public List<Product> Products { get; set; }
    }
}
