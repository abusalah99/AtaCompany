namespace AtaCompany;

public interface IWareUnitOfWork : IBaseUnitOfWorkSetting<Ware>
{
    Task<IEnumerable<Ware>> GetWaresByWareType(WareType wareType);
    Task<IEnumerable<Ware>> GetWaresForLocations(Location location);
    Task<IEnumerable<Ware>> GetWarsForLocationByWareType(Guid locationId, Guid wareTypeId);
}
