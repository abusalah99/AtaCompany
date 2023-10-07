using System.Diagnostics.Contracts;

namespace AtaCompany;

public class SupplierRepository : BaseRepositorySetting<Supplier>, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Supplier>> GetSuppliersForLocation(Location location) 
        => await dbSet.Where(e => e.LocationSuppliers != null && e.LocationSuppliers
                      .Any(e => e.LocationId == location.Id))
                      .ToListAsync();

    public async Task<IEnumerable<Supplier>> GetSuppliersForWareType(WareType wareType)
        => await dbSet.Where(e => e.SupplierWareTypes
                      .Any(e => e.WareTypeId == wareType.Id))
                      .ToListAsync();
}
