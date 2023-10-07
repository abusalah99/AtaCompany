using AtaCompany.Client.RazorComponents;

namespace AtaCompany.Client.Pages
{
    public partial class ContractorPage
    {
        [Inject]
        public HttpClient _client { get; set; } = null!;
        [Inject]
        private PopUpState _popUp { get; set; } = null!;

        [Parameter]
        public Guid LocationId { get; set; }

        private List<Contractor> contractors = new();
        private List<WareType> wareTypes = new();
        private Contractor request = new();

        private string popUpTitle = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            wareTypes = await GetWares();
            contractors = await GetContractors();
        }


        private async Task<List<WareType>> GetWares()
            => await _client.GetFromJsonAsync<List<WareType>>($"api/waretype") ?? new();

        private async Task<List<Contractor>> GetContractors()
            => await _client.GetFromJsonAsync<List<Contractor>>($"api/contractor/{LocationId}") ?? new();

        private async Task UpdateContractor()
        {

            await _client.PutAsJsonAsync<Contractor>("api/contractor", request);

            contractors = await GetContractors();

            TogglePopUpVisibility();
        }

        private async Task DeleteContractor()
        {
            await _client.DeleteAsync($"api/contractor/{request.Id}");

            contractors = await GetContractors();

            TogglePopUpVisibility();
        }

        private void TogglePopUpVisibility() => _popUp.TogglePopUpVisibility();



        private void TogglePopUpVisibilityForCreate()
        {
            request = new();

            popUpTitle = "اضافة مقاول";
            TogglePopUpVisibility();
        }

        private async Task SaveContractor()
        {
            List<LocationContractor> locationContractors = new() 
            {
                new() { LocationId = LocationId } 
            };
            request.LocationContracts = locationContractors;


            if (request.Penalty == string.Empty)
                request.Penalty = "لا خصومات ";

            await _client.PostAsJsonAsync<Contractor>("api/contractor", request);

            contractors = await GetContractors();

            TogglePopUpVisibility();
        }

        private async Task HandelFormAction()
        {
            switch (popUpTitle)
            {
                case "اضافة مقاول":
                    await SaveContractor();
                    break;
/*                case "تعديل مقاول":
                    await UpdateContractor();
                    break;*/
                case "حذف مقاول":
                    await DeleteContractor();
                    break;
            }
        }
        private void TogglePopUpVisibilityForEdit(Contractor contractor)
        {
            request = new();

            popUpTitle = "تعديل مقاول";

           /* request.WareTypeId = ware.WareTypeId;
            request.LocationId = ware.LocationId;

            request.Id = ware.Id;
            request.Name = ware.Name;
            request.EntranceDate = ware.EntranceDate;

            if (ware.DepartureDate != null)
                request.DepartureDate = ware.EntranceDate;

            request.Note = ware.Note;
            request.Price = ware.Price;
            request.Quantity = ware.Quantity;*/

            TogglePopUpVisibility();
        }
        private void TogglePopUpVisibilityForDelete(Guid contractorId)
        {
            request = new();

            popUpTitle = "حذف مقاول";

            request.Id = contractorId;

            TogglePopUpVisibility();
        }

    }
}
