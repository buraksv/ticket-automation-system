using Gronio.Utility.Common.Models;
using TicketSystem.Dto.Admin;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrders;

public sealed class TicketPurchaseOrderDetailDto : IDto
{
    public int Id { get; set; }
    public short AdminId { get; set; }
    public string Name { get; set; }
    public short TeamId { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public short TicketPlaceId { get; set; }
    public string TicketEventId { get; set; }
    public DateTime EventTime { get; set; }
    public DateTime AutomationRunTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool IsActive { get; set; }

    public AdminDetailDto Admin { get; set; }
}
