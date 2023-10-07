namespace AtaCompany;

public class LocationRepository : BaseRepositorySetting<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Location>> GetLocationsForContractor(Contractor contractor)
        => await dbSet.Where(e => e.LocationContractors != null && e.LocationContractors
                      .Any(e => e.ContractorId == contractor.Id))
                      .ToListAsync();

    public async Task<IEnumerable<Location>> GetLocationsForSupplier(Supplier Supplier)
        => await dbSet.Where(e => e.LocationSuppliers != null && e.LocationSuppliers
                      .Any(e => e.SupplierId == Supplier.Id))
                      .ToListAsync();
}