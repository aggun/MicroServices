using Microsoft.AspNetCore.Identity;

namespace identityserver.Models
{
   
    
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        
        
    }
}
