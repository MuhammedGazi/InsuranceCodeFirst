namespace InsuranceCodeFirst.Entity.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string? Status { get; set; }
    }
}
