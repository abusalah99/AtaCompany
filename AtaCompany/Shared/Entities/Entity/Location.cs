namespace AtaCompany;

public class Location : BaseEntitySetting
{
    public string Address { get; set; } = null!;
    public string ImagePath { get; set; } = string.Empty;
    [JsonIgnore]
    public IEnumerable<Ware>? Wares { get; set; }
    [JsonIgnore]
    public IEnumerable<LocationContractor>? LocationContractors { get; set; }
    [JsonIgnore]
    public IEnumerable<LocationSupplier>? LocationSuppliers { get; set; }
}