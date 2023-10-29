namespace AtaCompany;

public class LocationContractor
{
    public Guid LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public Contractor Contractor { get; set; } = null!;
    public DateTime DealDate { get; set; } = DateTime.Now;
    public string DealType { get; set; } = null!;
    public string DealBudget { get; set; } = null!;
    public string Penalty { get; set; } = string.Empty;
    public IEnumerable<Payment>? Payments { get; set; }
}
