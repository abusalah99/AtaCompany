namespace AtaCompany;

public class Contractor : BaseEntitySetting
{
    public DateTime DealDate { get; set; } = DateTime.Now;
    public string NationalId { get; set; } = null!;
    public string DealType { get; set; } = null!;
    public string DealBudget { get; set; } = null!;
    public string Penalty { get; set; } = string.Empty;
    public IEnumerable<Payment>? Payments { get; set; }
    public Guid WareTypeId { get; set; }
    [JsonIgnore]
    public WareType? WareType { get; set; }
    [JsonIgnore]
    public IEnumerable<LocationContractor>? LocationContracts { get; set; }
}
