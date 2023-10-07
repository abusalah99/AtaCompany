namespace AtaCompany;

public interface ILocationUnitOfWork : IBaseUnitOfWorkSetting<Location>
{
    Task<IEnumerable<Location>> GetLocationsForContractor(Contractor contractor);
    Task<IEnumerable<Location>> GetLocationsForSupplier(Supplier Supplier);
    Task<Location> MapFromLocationRequestToLocation(LocationRequest location, string absolutePath);
}
