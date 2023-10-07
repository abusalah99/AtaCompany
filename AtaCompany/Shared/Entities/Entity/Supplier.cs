namespace AtaCompany;

public class Supplier : BaseEntitySetting
{
    public string MobileNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public IEnumerable<SupplierWareType> SupplierWareTypes { get; set; } = null!;
    public IEnumerable<LocationSupplier>? LocationSuppliers { get; set; }
}