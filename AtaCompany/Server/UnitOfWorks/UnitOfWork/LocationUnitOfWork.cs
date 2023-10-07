namespace AtaCompany;

public class LocationUnitOfWork : BaseUnitOfWorkSetting<Location>, ILocationUnitOfWork
{
    private readonly ILocationRepository _repository;
    private readonly IFileSaver _fileSaver;

    public LocationUnitOfWork(ILocationRepository repository,
        IFileSaver fileSaver) : base(repository)
    {
        _repository = repository;
        _fileSaver = fileSaver;
    }

    public async Task<IEnumerable<Location>> GetLocationsForContractor(Contractor contractor)
        => await _repository.GetLocationsForContractor(contractor);

    public async Task<IEnumerable<Location>> GetLocationsForSupplier(Supplier Supplier)
        => await _repository.GetLocationsForSupplier(Supplier);

    public async Task<Location> MapFromLocationRequestToLocation(LocationRequest locationRequest, string rootPath)
    {
        Location location = new();

        location.Id = locationRequest.Id;
        location.Name = locationRequest.CustomerName;
        location.Address = locationRequest.Address;
        location.Wares = locationRequest.Wares;
        location.LocationContractors = locationRequest.LocationContractors;
        location.LocationSuppliers = locationRequest.LocationSuppliers;

        if (locationRequest.Image != null)
        {
            location.ImagePath = $"{@"\\Assets\Images\Locations\"}{locationRequest.Id}-{Guid.NewGuid().ToString()}.png";

            await DeleteFileIfExist(location.Id);

            await _fileSaver.Save(locationRequest.Image, $"{rootPath}{location.ImagePath}") ;

        }

        return location;
    }
    public override async Task Update(Location location)
    {
        Location locationFromDb = await _repository.Get(location.Id);
        
        if(location.ImagePath == string.Empty)
            location.ImagePath = locationFromDb.ImagePath;
        

        await base.Update(location);
    }

    public override async Task Delete(Location location)
    {
        await DeleteFileIfExist(location.Id) ;

        await base.Delete(location);
    }

    protected async Task DeleteFileIfExist(Guid locationId)
    {
        string directoryPath = @"wwwroot\Assets\Images\Locations\";
        string keyword = locationId.ToString();

        try
        {
            string[] files = Directory.EnumerateFiles(directoryPath)
                .Where(file => file.Contains(keyword))
                .ToArray();
            foreach (string file in files)
                await Task.Run(() => File.Delete(file));
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }



    }
}
