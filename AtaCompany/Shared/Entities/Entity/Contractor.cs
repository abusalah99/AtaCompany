namespace AtaCompany;

public class Contractor : BaseEntitySetting
{
    public DateTime DealDate { get; set; } = DateTime.Now;
    public string NationalId { get; set; } = null!;
    public string DealType { get; set; } = null!;
    public string DealBudget { get; set; } = null!;
    public string Penalty { get; set; } = string.Empty;
    public Payment Payment { get; set; } = new();
    public Guid WareTypeId { get; set; }
    [JsonIgnore]
    public WareType? WareType { get; set; }
    [JsonIgnore]
    public IEnumerable<LocationContractor>? LocationContracts { get; set; }
}
public record Payment {
    public string PaidMoney { get; set; } = string.Empty;
    public DateTime? PaymentDate {  get; set; } 
}
