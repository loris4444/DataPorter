using System.ComponentModel.DataAnnotations;

namespace DataPorter.Dto
{
    public class CustomerCreateDto
    {
        [Required]
        public required string Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Surname { get; set; }
        [EmailAddress, Required]
        public required string Email { get; set; }
        [Required]
        public required string Birthdate { get; set; }
        [Required]
        public required string CompanyId { get; set; }
    }
}
