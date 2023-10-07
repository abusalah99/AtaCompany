using System.ComponentModel.DataAnnotations;

namespace AtaCompany;

public class Ware : BaseEntitySetting
{
    public int Quantity { get; set; }   
    public string Price { get; set; } = null!; 
    public string Note { get; set; } = string.Empty;
    public DateTime EntranceDate { get; set; } = DateTime.Now;
    public DateTime? DepartureDate { get; set; }

    public Guid WareTypeId { get; set; } = Guid.Empty!;
    [JsonIgnore]
    public WareType? WareType { get; set; }
    public Guid LocationId { get; set; } = Guid.Empty!;
    [JsonIgnore]
    public Location? Location { get; set; } 
}