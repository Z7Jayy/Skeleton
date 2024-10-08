namespace WebApplication1.Models;

public class UserSession
{
    public int SessionId { get; set; }
    public int UserId { get; set; }
    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }
    public bool IsActive { get; set; }
}