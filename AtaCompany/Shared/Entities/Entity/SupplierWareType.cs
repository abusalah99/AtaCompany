namespace AtaCompany;

public class SupplierWareType
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
    public Guid WareTypeId { get; set; } 
    public WareType WareType { get; set;} = null!;
}