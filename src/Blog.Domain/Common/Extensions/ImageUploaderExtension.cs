using System.Drawing;
using System.Drawing.Imaging;

namespace Blog.Domain.Common.Extensions;

public static class ImageUploaderExtension
{
    public static void AddImage(this Image image, string fileName, string filePath, string deleteFileName = null)
    {
        if (image != null)
        {
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            if (!string.IsNullOrEmpty(deleteFileName)) File.Delete(filePath + deleteFileName);

            string originalPath = filePath + fileName;

            using var stream = new FileStream(originalPath, FileMode.Create);
            if (!Directory.Exists(originalPath)) image.Save(stream, ImageFormat.Jpeg);
        }
    }

    public static Image Base64ToImage(string base64String)
    {
        var response = DecodeUrlBase64(base64String);
        MemoryStream memoryStream = new MemoryStream(response, 0, response.Length);
        memoryStream.Write(response, 0, response.Length);
        Image image = Image.FromStream(memoryStream, true);
        return image;
    }

    private static byte[] DecodeUrlBase64(string base64String) =>
        Convert.FromBase64String(base64String[(base64String.LastIndexOf(',') + 1)..]);
}