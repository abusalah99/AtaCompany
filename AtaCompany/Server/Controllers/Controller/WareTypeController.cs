namespace AtaCompany;

[Route("api/[controller]")]
[ApiController]
public class WareTypeController : BaseControllerSetting<WareType>
{
    public WareTypeController(IWareTypeUnitOfWork unitOfWork) : base(unitOfWork) { }

    [HttpGet]
    public async Task<IActionResult> Get() => await ReadAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) => await ReadAsync(id);

    [HttpPost]
    public async Task<IActionResult> Post(WareType wareType) => await CreateAsync(wareType);

    [HttpPut]
    public async Task<IActionResult> Put(WareType wareType) => await UpdateAsync(wareType);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) => await RemoveAysnc(id);

}
