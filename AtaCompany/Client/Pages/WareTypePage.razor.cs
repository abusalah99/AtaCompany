using System.Reflection.Metadata.Ecma335;

namespace AtaCompany.Client.Pages;

public partial class WareTypePage
{
    [Inject]
    public HttpClient _client { get; set; } = null!;

    [Parameter]
    public Guid Id { get; set; }

    private List<WareType> wareTypes = new();

    protected override async Task OnInitializedAsync() => wareTypes = await GetWareTypes();

    private async Task<List<WareType>> GetWareTypes()
        => await _client.GetFromJsonAsync<List<WareType>>("api/waretype") ?? new();
}
