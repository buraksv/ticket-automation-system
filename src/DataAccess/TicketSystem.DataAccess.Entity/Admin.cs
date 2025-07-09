using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class Admin : Entity<short>, IHasCreatedTimeEntity, IUndeletableEntity, IStatusEntity, IHasUpdatedTimeEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MailAddress { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }
    public DateTime? UpdatedTime { get; set; }
}