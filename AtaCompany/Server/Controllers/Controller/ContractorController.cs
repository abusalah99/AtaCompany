namespace AtaCompany;

[Route("api/[controller]")]
[ApiController]

public class ContractorController : BaseControllerSetting<Contractor>
{
    private readonly IContractorUnitOfWork _unitOfWork;

    public ContractorController(IContractorUnitOfWork unitOfWork) : base(unitOfWork) =>  _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get() => await ReadAsync();
    [HttpGet("{locationId}")]
    public async Task<IActionResult> Get(Guid locationId)
        => Ok(await _unitOfWork.GetContractorsForLocation(locationId));

    [HttpPost]
    public async Task<IActionResult> Post(Contractor contractor) => await CreateAsync(contractor);

    [HttpPut]
    public async Task<IActionResult> Put(Contractor contractor) => await UpdateAsync(contractor);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) => await RemoveAysnc(id);

}

