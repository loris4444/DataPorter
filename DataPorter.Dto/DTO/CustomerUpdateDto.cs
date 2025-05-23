using System.ComponentModel.DataAnnotations;

namespace DataPorter.Dto
{
    public class CustomerUpdateDto
    {
        [Required]
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Birthdate { get; set; }
        public string? CompanyId { get; set; }
    }
}
