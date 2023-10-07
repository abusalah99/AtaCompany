namespace AtaCompany;

public class SupplierUnitOfWork : BaseUnitOfWorkSetting<Supplier>, ISupplierUnitOfWork
{
    private readonly ISupplierRepository _repository;

    public SupplierUnitOfWork(ISupplierRepository repository)
        : base(repository) => _repository = repository ;

    public async Task<IEnumerable<Supplier>> GetSuppliersForLocation(Location location)
        => await _repository.GetSuppliersForLocation(location);

    public async Task<IEnumerable<Supplier>> GetSuppliersForWareType(WareType wareType)
        => await _repository.GetSuppliersForWareType(wareType);
}
