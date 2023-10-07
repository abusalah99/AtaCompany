namespace AtaCompany;

public class WareTypeUnitOfWork : BaseUnitOfWorkSetting<WareType>, IWareTypeUnitOfWork
{
    public WareTypeUnitOfWork(IWareTypeRepository repository) : base(repository) { }
}
