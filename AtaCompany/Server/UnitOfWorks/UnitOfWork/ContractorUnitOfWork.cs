namespace AtaCompany;

public class ContractorUnitOfWork : BaseUnitOfWorkSetting<Contractor>, IContractorUnitOfWork
{
    private readonly IContractorRepository _repository;

    public ContractorUnitOfWork(IContractorRepository repository)
        : base(repository) => _repository = repository;

    public async Task<IEnumerable<Contractor>> GetContractorsForLocation(Guid locationId)
        => await _repository.GetContractorsForLocation(locationId);

    public async Task<IEnumerable<Contractor>> GetContractorsForWareType(WareType wareType) 
        => await _repository.GetContractorsForWareType(wareType);
}
