namespace AtaCompany;

public class WareRepository : BaseRepositorySetting<Ware>, IWareRepository
{
    public WareRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Ware>> GetWaresByWareType(WareType wareType)
        => await dbSet.Where(e => e.WareTypeId == wareType.Id).ToListAsync();

    public async Task<IEnumerable<Ware>> GetWaresForLocations(Location location)
        => await dbSet.Where(e => e.LocationId == location.Id).ToListAsync();

    public async Task<IEnumerable<Ware>> GetWarsForLocationByWareType(Guid locationId , Guid wareTypeId)
        => await dbSet.Where(e => e.WareTypeId == wareTypeId && e.LocationId == locationId)
                      .AsSplitQuery()
                      .ToListAsync();
}
