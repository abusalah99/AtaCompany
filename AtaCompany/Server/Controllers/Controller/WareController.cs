namespace AtaCompany;

[Route("api/[controller]")]
[ApiController]
public class WareController : BaseControllerSetting<Ware>
{
    private readonly IWareUnitOfWork _unitOfWork;

    public WareController(IWareUnitOfWork unitOfWork) : base(unitOfWork) => _unitOfWork = unitOfWork;
    
    [HttpGet("{locationId}/{wareTypeId}")]
    public async Task<IActionResult> Get(Guid locationId, Guid wareTypeId)
        => Ok(await _unitOfWork.GetWarsForLocationByWareType(locationId, wareTypeId));

    [HttpPost]
    public async Task<IActionResult> Post(Ware ware) => await CreateAsync(ware);

    [HttpPut]
    public async Task<IActionResult> Put(Ware ware) => await UpdateAsync(ware);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) => await RemoveAysnc(id);
}
