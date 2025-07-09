using Gronio.Utility.Common.Models;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Dto.TicketPurchaseOrderAccounts;

public sealed class TicketPurchaseOrderAccountDetailDto : IDto
{
    public int Id { get; set; }
    public int TicketPurchaseOrderId { get; set; }
    public int TicketAccountDefinitionId { get; set; }
    public Dictionary<string, string> TicketEventOrderSelections { get; set; }
    public short Count { get; set; }
    public short OrderedCount { get; set; }
    public DateTime CreatedTime { get; set; }

    public AdminDetailDto Admin { get; set; }

}
