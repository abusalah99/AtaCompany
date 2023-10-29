namespace AtaCompany;

public class Contractor : BaseEntitySetting
{
    public string NationalId { get; set; } = null!;
    public Guid WareTypeId { get; set; }
    public WareType? WareType { get; set; }
    [JsonIgnore]
    public IEnumerable<LocationContractor>? LocationContracts { get; set; }
}
