namespace AtaCompany;

public interface IContractorRepository : IBaseRepositorySetting<Contractor>
{
    Task<IEnumerable<Contractor>> GetContractorsForLocation(Guid locationId);
    Task<IEnumerable<Contractor>> GetContractorsForWareType(WareType wareType);
}
