namespace AtaCompany;

public class BaseController<TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    private readonly IBaseUnitOfWork<TEntity> _unitOfWork;
    public BaseController(IBaseUnitOfWork<TEntity> unitOfWork) => _unitOfWork = unitOfWork;

    protected virtual async Task<IActionResult> CreateAsync(TEntity entity)
    {
        await _unitOfWork.Create(entity);

        return Ok(JsonSerializer.Serialize($"{typeof(TEntity).Name} Created"));
    }

    protected virtual async Task<IActionResult> ReadAsync()
    {
        IEnumerable<TEntity> entities = await _unitOfWork.Read();

        return Ok(entities);
    }
    protected virtual async Task<IActionResult> ReadAsync(Guid id)
    {
        TEntity entity = await _unitOfWork.Read(id);

        return Ok(entity);
    }

    protected async virtual Task<IActionResult> UpdateAsync(TEntity entity)
    {
        await _unitOfWork.Update(entity);

        return Ok(JsonSerializer.Serialize($"{typeof(TEntity).Name} Updated"));
    }

    protected async virtual Task<IActionResult> RemoveAysnc(Guid id)
    {
        await _unitOfWork.Delete(id);

        return Ok(JsonSerializer.Serialize($"{typeof(TEntity).Name} Deleted"));
    }
    protected async virtual Task<IActionResult> RemoveAysnc(TEntity entity)
    {
        await _unitOfWork.Delete(entity);

        return Ok(JsonSerializer.Serialize($"{typeof(TEntity).Name} Deleted"));
    }

    protected void SetCookie(string name, string value, DateTime expireTime)
    => Response.Cookies.Append(name, value
        , new CookieOptions()
        {
            HttpOnly = true,
            Expires = expireTime
        });

    protected Guid GetUserId()
    {
        var id = User.FindFirst("Id") ?? new("Id", Guid.Empty.ToString());

        return new Guid(id.Value);
    }

}

