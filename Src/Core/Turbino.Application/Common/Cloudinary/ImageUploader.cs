using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Turbino.Infrastructure
{
    public class ImageUploader
    {
        private readonly IConfigurationSection CloudinarySection;

        public ImageUploader(IConfiguration configuration)
        {
            this.CloudinarySection = configuration.GetSection("Cloudinary");
        }

        public string UploadImage(IFormFile fileform, string articleTitle)
        {
            var cloudinary = SetCloudinary();

            if (fileform == null)
            {
                return null;
            }

            byte[] articleImg;

            using (var memoryStream = new MemoryStream())
            {
                fileform.CopyTo(memoryStream);
                articleImg = memoryStream.ToArray();
            }

            ImageUploadResult uploadResult;

            using (var ms = new MemoryStream(articleImg))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(articleTitle, ms),
                    Transformation = new Transformation(),
                };

                uploadResult = cloudinary.Upload(uploadParams);
            }

            return uploadResult.SecureUri.AbsoluteUri;
        }

        private Cloudinary SetCloudinary()
        {
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account
            {
                Cloud = CloudinarySection["CloudName"],
                ApiKey = CloudinarySection["CloudinaryApiKey"],
                ApiSecret = CloudinarySection["CloudinaryApiSecret"],
            };

            Cloudinary cloudinary = new Cloudinary(account);
            return cloudinary;
        }
    }
}
