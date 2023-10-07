

namespace AtaCompany;

public class WareType : BaseEntitySetting
{
    [JsonIgnore]
    public IEnumerable<Ware>? Wares { get; set; }
    [JsonIgnore]
    public IEnumerable<Contractor>? Contractors { get; set; }
    [JsonIgnore]
    public IEnumerable<SupplierWareType>? SupplierWareTypes { get; set; }
}