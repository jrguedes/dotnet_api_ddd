namespace API.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value ?? "Employee"; }
        }                    
    }
}
