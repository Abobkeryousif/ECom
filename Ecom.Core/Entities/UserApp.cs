using Microsoft.AspNetCore.Identity;
namespace Ecom.Core.Entities
{
   public class UserApp : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address  { get; set; }


    }
}
