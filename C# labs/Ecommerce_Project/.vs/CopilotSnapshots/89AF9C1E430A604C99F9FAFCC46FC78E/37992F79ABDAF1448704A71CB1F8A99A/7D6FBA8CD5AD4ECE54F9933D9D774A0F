using Ecommerce_Project.Services.Interfaces;

namespace Ecommerce_Project.Services.implementation
{
    public class ImageService : IImageService
    {

        private readonly IWebHostEnvironment env;

        public ImageService(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folderName)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, folderName);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileExtension = Path.GetExtension(file.FileName);

            if (string.IsNullOrEmpty(fileExtension) || !new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension.ToLower()))
            {
                throw new InvalidOperationException("Invalid file type.");
            }

            var fileName = Guid.NewGuid().ToString() + fileExtension;

            var filePath = Path.Combine(uploadsFolder, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(fileStream);

            return $"/{folderName}/{fileName}".Replace("\\", "/");
        }



        public Task<bool> DeleteImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return Task.FromResult(false);
            }

            var cleanPath = imageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var fullPath = Path.Combine(env.WebRootPath, cleanPath);

            if (!File.Exists(fullPath))
            {
                return Task.FromResult(false);
            }

            File.Delete(fullPath);
            return Task.FromResult(true);
        }

    }
}
