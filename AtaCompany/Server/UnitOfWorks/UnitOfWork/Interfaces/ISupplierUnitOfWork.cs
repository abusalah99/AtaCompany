namespace AtaCompany;

public interface ISupplierUnitOfWork : IBaseUnitOfWorkSetting<Supplier>
{
    Task<IEnumerable<Supplier>> GetSuppliersForLocation(Location location);
    Task<IEnumerable<Supplier>> GetSuppliersForWareType(WareType wareType);
}
