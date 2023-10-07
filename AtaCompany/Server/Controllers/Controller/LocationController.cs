namespace AtaCompany;

[Route("api/[controller]")]
[ApiController]
public class LocationController : BaseControllerSetting<Location>
{
    private readonly ILocationUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public LocationController(ILocationUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => await ReadAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) => await ReadAsync(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromForm]LocationRequest request)
    {
        request.Id = Guid.NewGuid();

        Location location = await _unitOfWork.MapFromLocationRequestToLocation(request, _hostEnvironment.WebRootPath);

        return await CreateAsync(location);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromForm] LocationRequest request)
    {
        Location location = await _unitOfWork.MapFromLocationRequestToLocation(request, _hostEnvironment.WebRootPath);

        return await UpdateAsync(location);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Location location) => await RemoveAysnc(location);
}