using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseOrderAccounts;

public sealed class TicketPurchaseOrderAccountUpdateRequestDto : IDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    public int Id { get; set; } 
    public int TicketPurchaseOrderId { get; set; }
    public int TicketAccountDefinitionId { get; set; }
    public Dictionary<string, string> TicketEventOrderSelections { get; set; }
    public short Count { get; set; }
    public short OrderedCount { get; set; }
}