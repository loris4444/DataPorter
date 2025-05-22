using System.ComponentModel.DataAnnotations;

namespace DataPorter.Entity
{
    public class Customer
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required DateTime Birthdate { get; set; }

        public required string CompanyId { get; set; }
        public required Company Company { get; set; }
    }
}
