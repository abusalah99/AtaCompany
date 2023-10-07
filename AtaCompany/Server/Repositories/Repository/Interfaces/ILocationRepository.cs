namespace AtaCompany;

public interface ILocationRepository : IBaseRepositorySetting<Location>
{
    Task<IEnumerable<Location>> GetLocationsForContractor(Contractor contractor);
    Task<IEnumerable<Location>> GetLocationsForSupplier(Supplier supplier);
}