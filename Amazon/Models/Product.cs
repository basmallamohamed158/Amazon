using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        [Required]
        [Range(0.01 , 1000)]
        public double Product_Price { get; set; }
        [Range(0 , 1000)]
        public int Product_Quantity { get; set; }
        
       public  int userId {  get; set; }
        public User user { get; set; }
    }
}
