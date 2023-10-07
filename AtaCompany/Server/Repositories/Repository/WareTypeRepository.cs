namespace AtaCompany;

public class WareTypeRepository : BaseRepositorySetting<WareType>, IWareTypeRepository
{
    public WareTypeRepository(ApplicationDbContext context) : base(context) { }
}
