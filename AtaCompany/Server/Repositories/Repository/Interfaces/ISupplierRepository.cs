namespace AtaCompany;

public interface ISupplierRepository : IBaseRepositorySetting<Supplier>
{
    Task<IEnumerable<Supplier>> GetSuppliersForLocation(Location location);
    Task<IEnumerable<Supplier>> GetSuppliersForWareType(WareType wareType);
}
