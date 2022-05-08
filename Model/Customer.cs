using System;
using System.ComponentModel.DataAnnotations;

namespace RestServer.Model
{
    public class Customer
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [Range(19, 90, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }
    }
}
