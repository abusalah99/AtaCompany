namespace AtaCompany;

public class LocationSupplier
{
    public Guid LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
}
