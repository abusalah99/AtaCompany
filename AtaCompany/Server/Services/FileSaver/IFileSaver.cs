namespace AtaCompany;

public interface IFileSaver 
{
    public Task Save(IFormFile file, string FilePath);
}
