using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketAccountDefinitions;

public sealed class TicketAccountDefinitionCreateRequestDto : IDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public TicketAccountTypeEnum AccountType { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public short TeamId { get; set; }
    public Dictionary<string, string> TicketSystemLoginInformation { get; set; }
    public bool TicketSystemIsValid { get; set; }
    public DateTime? TicketSystemLastValidationControlTime { get; set; }
    public bool IsActive { get; set; }
}