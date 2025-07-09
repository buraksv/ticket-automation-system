using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class AdminLogin : Entity<int>, IHasCreatedTimeEntity
{
    public short? AdminId { get; set; }
    public string IpAddress { get; set; }
    public bool IsSuccess { get; set; }
    public string InputUsername { get; set; }
    public string InputPassword { get; set; }
    public DateTime CreatedTime { get; set; }

    public Admin? Admin { get; set; }
}