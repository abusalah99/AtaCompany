namespace AtaCompany;

public class LocationRequest : BaseEntity
{
    public string CustomerName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public IFormFile? Image { get; set; } 
    public IEnumerable<Ware>? Wares { get; set; }
    public IEnumerable<LocationContractor>? LocationContractors { get; set; }
    public IEnumerable<LocationSupplier>? LocationSuppliers { get; set; }
}
