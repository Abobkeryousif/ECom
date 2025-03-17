namespace Ecom.Core.DTO
{
   public record RegisterDto : LoginDto
    {
        public string UserName { get; set; }
    
    }

    public record LoginDto
    {
        public string Email { get; set; }

        public string DisplayName { get; set; } 
        public string Password { get; set; }
    }
}
