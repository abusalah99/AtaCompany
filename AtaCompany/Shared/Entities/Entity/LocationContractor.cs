namespace AtaCompany;

public class LocationContractor
{
    public Guid LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public Guid ContractorId { get; set; }
    public Contractor Contractor { get; set; } = null!;
}
