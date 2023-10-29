namespace AtaCompany;

public class Payment : BaseEntity 
{
    public string PaidMoney { get; set; } = string.Empty;
    public DateTime PaymentDate {  get; set; } = DateTime.Now;  
    public LocationContractor LocationContractor { get; set; } = null!;
    public Guid LocationId { get; set; }
    public Guid ContractorId { get; set; }

}
