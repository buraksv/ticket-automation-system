namespace TicketSystem.Dto.ExternalApiResponseModels;

public sealed class PassoLigGetContactResponseModel
{
    public int TotalItemCount { get; set; }
    public ContactDetail Value { get; set; }
    public bool IsError { get; set; }
    public int ResultCode { get; set; }
} 

public sealed class ContactDetail
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string MobilePhone { get; set; }
    public string UnMaskedMobilePhone { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public bool IsCorporate { get; set; }
    public string CountryCode { get; set; }
    public string NationalId { get; set; }
    public bool HaveLoyaltyCard { get; set; }
    public bool IsFirstLogin { get; set; }
    public bool IsAgreement { get; set; }
    public DateTime BirthDate { get; set; }
}
