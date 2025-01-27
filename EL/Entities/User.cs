using EL.Common;

namespace EL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Name={Name}, Email={Email}, IsActive={IsActive}, Roles={RoleId}";
        }
    }
}
