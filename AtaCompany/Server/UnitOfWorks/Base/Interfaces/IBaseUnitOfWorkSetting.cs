namespace AtaCompany;

public interface IBaseUnitOfWorkSetting<TEntity> 
    : IBaseUnitOfWork<TEntity> where TEntity : BaseEntitySetting
{
    Task<IEnumerable<TEntity>> Search(string searchText);
}
