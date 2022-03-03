namespace Ecommerce.Application.Model
{
    public class RoleInCompany
    {
        public string RoleName { get; set; }
        public CompanySummary Company { get; set; }

        public string ToClaim() => $"{Company.Id}:{RoleName}";
    }
}
