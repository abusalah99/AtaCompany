namespace AtaCompany;

public interface IWareRepository : IBaseRepositorySetting<Ware>
{
    Task<IEnumerable<Ware>> GetWaresByWareType(WareType wareType);
    Task<IEnumerable<Ware>> GetWaresForLocations(Location location);
    Task<IEnumerable<Ware>> GetWarsForLocationByWareType(Guid locationId, Guid wareTypeId);
}
