using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheZ.Entities
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(100, ErrorMessage ="Maximum length of the name is 100 character")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters")]
        public string? Address { get; set; }
        public string? Country { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}