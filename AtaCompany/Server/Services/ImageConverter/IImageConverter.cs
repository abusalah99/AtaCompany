namespace AtaCompany;

public interface IImageConverter
{
    Task<byte[]> ConvertImage(IFormFile image); 
}
