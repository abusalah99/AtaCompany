namespace AtaCompany;

public class Payment : BaseEntity 
{
    public string PaidMoney { get; set; } = string.Empty;
    public DateTime PaymentDate {  get; set; } = DateTime.Now;  
    public Contractor Contractor { get; set; } = null!;
    public Guid ContractorId { get; set; }

}
