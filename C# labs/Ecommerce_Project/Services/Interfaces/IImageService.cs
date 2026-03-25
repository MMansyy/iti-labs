namespace Ecommerce_Project.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile file, string folderName);
        Task<bool> DeleteImageAsync(string imageUrl);
    }
}
