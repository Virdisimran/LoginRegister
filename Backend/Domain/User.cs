namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DOB { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int IsActive { get; set; }   
        public ICollection<Product>? Products { get; set; }
    }
}