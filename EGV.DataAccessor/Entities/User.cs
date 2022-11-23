using Microsoft.AspNetCore.Identity;

namespace EGV.DataAccessor.Entities
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Boolean IsLogged { get; set; }
    }
}