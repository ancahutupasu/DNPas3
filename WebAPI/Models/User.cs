using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
      
        public int Id { get; set; }
        
        public string UserName { get; set; }
     
        public string Password { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }
    }
}