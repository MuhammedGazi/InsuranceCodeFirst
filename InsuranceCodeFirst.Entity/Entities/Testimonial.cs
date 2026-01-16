namespace InsuranceCodeFirst.Entity.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public int starCount { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
