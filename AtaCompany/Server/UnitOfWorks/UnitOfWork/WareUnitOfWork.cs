namespace AtaCompany;

public class WareUnitOfWork : BaseUnitOfWorkSetting<Ware>, IWareUnitOfWork
{
    private readonly IWareRepository _repository;

    public WareUnitOfWork(IWareRepository repository) : base(repository) => _repository = repository;

    public async Task<IEnumerable<Ware>> GetWaresByWareType(WareType wareType)
        => await _repository.GetWaresByWareType(wareType);

    public async Task<IEnumerable<Ware>> GetWaresForLocations(Location location)
        => await _repository.GetWaresForLocations(location);

    public async Task<IEnumerable<Ware>> GetWarsForLocationByWareType(Guid locationId, Guid wareTypeId)
        => await _repository.GetWarsForLocationByWareType(locationId, wareTypeId);
}
