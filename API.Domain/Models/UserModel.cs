using System;

namespace API.Domain.Models
{
    public class UserModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Email { get; set; }

        public int Name { get; set; }
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime UpdatedAt { get; set; }

        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value ?? "Employee"; }
        }                        
    }
}
