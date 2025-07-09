using System.ComponentModel;

namespace TicketSystem.Enums;

public enum TicketAccountDefinitionPagedListOrderEnum : byte
{
    None = 0,
    [Description("Name And Surname Ascending")]
    NameAndSurnameAscending = 1,
    [Description("Name And Surname Descending")]
    NameAndSurnameDescending = 2,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 3,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 4,
}