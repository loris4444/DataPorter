namespace DataPorter.Entity
{
    public class Company
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required DateOnly FoundationDate { get; set; }
        public required int Employees { get; set; }
        public required double Revenue { get; set; }

        public required ICollection<Customer> Customers { get; set; }

    }
}
