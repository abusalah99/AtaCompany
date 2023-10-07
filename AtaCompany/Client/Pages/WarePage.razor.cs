using AtaCompany.Client.RazorComponents;

namespace AtaCompany.Client.Pages;

public partial class WarePage
{
    [Inject]
    public HttpClient _client { get; set; } = null!;
    [Inject]
    private PopUpState _popUp { get; set; } = null!;

    [Parameter]
    public Guid LocationId { get; set; }

    [Parameter]
    public Guid WareTypeId { get; set; }

    private List<Ware> wares = new();
    private Ware request = new();
    private List<int> totalNet = new();

    private string popUpTitle = string.Empty;

    protected override async Task OnInitializedAsync() => wares = await GetWares(); 

    private async Task<List<Ware>> GetWares()
        => await _client.GetFromJsonAsync<List<Ware>>($"api/ware/{LocationId}/{WareTypeId}") ?? new();

    private async Task UpdateWare()
    {
        if (request.Note == string.Empty)
            request.Note = "لا يوجد ملاحظات";

        await _client.PutAsJsonAsync<Ware>("api/ware", request);

        wares = await GetWares();

        TogglePopUpVisibility();
    }

    private async Task DeleteWare()
    {
        await _client.DeleteAsync($"api/ware/{request.Id}");
        wares = await GetWares();

        TogglePopUpVisibility();
    }

    private void TogglePopUpVisibility() => _popUp.TogglePopUpVisibility();

    

    private void TogglePopUpVisibilityForCreate()
    {
        request = new();

        popUpTitle = "اضافة بضاعة";
        TogglePopUpVisibility();
    }

    private async Task SaveWare()
    {
        request.WareTypeId = WareTypeId;
        request.LocationId = LocationId;

        if (request.Note == string.Empty)
            request.Note ="لا يوجد ملاحظات";

        await _client.PostAsJsonAsync<Ware>("api/ware", request);

        wares = await GetWares();

        TogglePopUpVisibility();
    }

    private async Task HandelFormAction()
    {
        switch (popUpTitle)
        {
            case "اضافة بضاعة":
                await SaveWare();
                break;
            case "تعديل بضاعة":
                await UpdateWare();
                break;
            case "حذف بضاعة":
                await DeleteWare();
                break;
        }
    }
    private void TogglePopUpVisibilityForEdit(Ware ware)
    {
        request = new();

        popUpTitle = "تعديل بضاعة";

        request.WareTypeId = ware.WareTypeId;
        request.LocationId = ware.LocationId;

        request.Id = ware.Id;
        request.Name = ware.Name;
        request.EntranceDate = ware.EntranceDate;

        if (ware.DepartureDate != null)
            request.DepartureDate = ware.EntranceDate;

        request.Note = ware.Note;
        request.Price = ware.Price;
        request.Quantity = ware.Quantity;

        TogglePopUpVisibility();
    }
    private void TogglePopUpVisibilityForDelete(Guid wareId)
    {
        request = new();

        popUpTitle = "حذف بضاعة";

        request.Id = wareId;

        TogglePopUpVisibility();
    }
    private int AddPriceToTotalNet(int price)
    {
        totalNet.Add(price);
        return price;
    }
    private int CalculateSum()
    {
        int sum = totalNet.Sum();
        totalNet.Clear();
        return sum;
    }
}
