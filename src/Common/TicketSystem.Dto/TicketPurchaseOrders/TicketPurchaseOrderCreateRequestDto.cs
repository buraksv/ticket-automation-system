﻿using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrders;

public sealed class TicketPurchaseOrderCreateRequestDto : IDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public short TeamId { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public short TicketPlaceId { get; set; }
    public string TicketEventId { get; set; }
    public DateTime EventTime { get; set; }
    public DateTime AutomationRunTime { get; set; }
    public bool IsActive { get; set; }
} 