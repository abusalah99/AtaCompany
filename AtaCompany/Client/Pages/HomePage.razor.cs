using AtaCompany.Client.RazorComponents;

namespace AtaCompany.Client.Pages;

public partial class HomePage
{
    [Inject]
    public HttpClient _client { get; set; } = null!;
    [Inject]
    private PopUpState _popUp { get; set; } = null!;

    private LocationRequest request = new();

    private IBrowserFile? image;

    private List<Location> locations = new();
    private List<Location>? renderLocations;
    private Location locationForDelete = null!;
    private string popUpTitle = string.Empty;

    protected override async Task OnInitializedAsync() => locations = await GetLocations();

    private async Task<List<Location>> GetLocations()
        => await _client.GetFromJsonAsync<List<Location>>("api/location") ?? new();

    private async Task SaveLocation()
    {
        var formData = new MultipartFormDataContent();
        if (image != null)
        {
            var memoryStream = new MemoryStream();
            await image.OpenReadStream(5 * 1024 * 1024).CopyToAsync(memoryStream);
            var imageContent = new ByteArrayContent(memoryStream.ToArray());

            formData.Add(imageContent, "Image", image.Name);
        }
        formData.Add(new StringContent(request.CustomerName), "CustomerName");
        formData.Add(new StringContent(request.Address), "Address");

        await _client.PostAsync("api/location", formData);

        request = new();

        locations = await GetLocations();

        image = null;

        TogglePopUpVisibility();
    }
    private async Task UpdateLocation()
    {
        var formData = new MultipartFormDataContent();
        if (image != null)
        {
            var memoryStream = new MemoryStream();
            await image.OpenReadStream(5 * 1024 * 1024).CopyToAsync(memoryStream);
            var imageContent = new ByteArrayContent(memoryStream.ToArray());

            formData.Add(imageContent, "Image", image.Name);
        }
        formData.Add(new StringContent(request.CustomerName), "CustomerName");
        formData.Add(new StringContent(request.Address), "Address");
        formData.Add(new StringContent(request.Id.ToString()), "Id");

        await _client.PutAsync("api/location", formData);

        request = new();

        locations = await GetLocations();

        image = null;

        TogglePopUpVisibility();
    }

    private async Task DeleteLocation(Location location)
    {

        await _client.SendAsync(new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"{NavigationManager.BaseUri}api/location"),
            Content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json")
        });


        locations = await GetLocations();

        TogglePopUpVisibility();

        _searchParameters.FilteredItems = locations.Where(e => e.Name.Contains(_searchParameters.SearchText ?? "")).ToList();

    }

    private void TogglePopUpVisibility()
    {
        _popUp.TogglePopUpVisibility();

        if (_popUp.IsPopUpVisible)
        {
            _searchParameters.FilteredItems.Clear();
            _searchParameters.Suggestions.Clear();
            _searchParameters.SearchText = string.Empty;
        }
    }

    private void TogglePopUpVisibilityForCreate()
    {
        popUpTitle = "اضافة موقع";
        TogglePopUpVisibility();
    }

    private void TogglePopUpVisibilityForEdit(Location location)
    {
        popUpTitle = "تعديل موقع";

        request.Id = location.Id;
        request.CustomerName = location.Name;
        request.Address = location.Address;

        TogglePopUpVisibility();
    }
    private void TogglePopUpVisibilityForDelete(Location location)
    {
        popUpTitle = "حذف موقع";

        locationForDelete = location;

        TogglePopUpVisibility();
    }

    private async Task HandelFormAction()
    {
        switch (popUpTitle)
        {
            case "اضافة موقع" :
                await SaveLocation();
                break;
            case "تعديل موقع":
                await UpdateLocation();
                break;
            case "حذف موقع":
                await DeleteLocation(locationForDelete);
                break;
        }
}

    private void HandleFileUpload(InputFileChangeEventArgs e) => image = e.File;

}

