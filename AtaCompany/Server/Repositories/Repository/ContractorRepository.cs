namespace AtaCompany;

public class ContractorRepository : BaseRepositorySetting<Contractor>, IContractorRepository
{
    public ContractorRepository(ApplicationDbContext context) : base(context) { }

    public override async Task<IEnumerable<Contractor>> Get() => await dbSet.AsSplitQuery()
                                                                            .Include(e=>e.WareType)
                                                                            .ToListAsync();

    public async Task<IEnumerable<Contractor>> GetContractorsForLocation(Guid locationId)
        => await dbSet.Where(e => e.LocationContracts != null && e.LocationContracts
                      .Any(e => e.LocationId == locationId))
                      .AsSplitQuery()
                      .ToListAsync();

    public async Task<IEnumerable<Contractor>> GetContractorsForWareType(WareType wareType) 
        =>  await dbSet.Where(e=>e.WareTypeId == wareType.Id).ToListAsync();
}
