namespace Turbino.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using System.IO;

    public class ImageUploader
    {
        private readonly IConfigurationSection CloudinarySection;

        public ImageUploader(IConfiguration configuration)
        {
            this.CloudinarySection = configuration.GetSection("Cloudinary");
        }

        public string UploadImage(IFormFile fileform, string articleTitle)
        {
            Cloudinary cloudinary = SetCloudinary();

            if (fileform == null)
            {
                return null;
            }

            byte[] articleImg;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileform.CopyTo(memoryStream);
                articleImg = memoryStream.ToArray();
            }

            ImageUploadResult uploadResult;

            using (MemoryStream ms = new MemoryStream(articleImg))
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
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
            Account account = new Account
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
