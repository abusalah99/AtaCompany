namespace AtaCompany;

public interface IContractorUnitOfWork : IBaseUnitOfWorkSetting<Contractor>
{
    Task<IEnumerable<Contractor>> GetContractorsForLocation(Guid locationId);
    Task<IEnumerable<Contractor>> GetContractorsForWareType(WareType wareType);
}
