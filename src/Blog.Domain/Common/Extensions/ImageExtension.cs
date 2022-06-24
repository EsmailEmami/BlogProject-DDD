using System.Drawing;
using System.Drawing.Imaging;

namespace Blog.Domain.Common.Extensions;

public static class ImageExtension
{
    public static void AddImage(this Image image, string fileName, string filePath, string deleteFileName = null)
    {
        if (image != null)
        {
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            if (!string.IsNullOrEmpty(deleteFileName)) DeleteImage(filePath + deleteFileName);

            string originalPath = filePath + fileName;

            using var stream = new FileStream(originalPath, FileMode.Create);
            if (!Directory.Exists(originalPath)) image.Save(stream, ImageFormat.Jpeg);
        }
    }

    public static Image Base64ToImage(string base64String)
    {
        try
        {
            var response = DecodeUrlBase64(base64String);
            MemoryStream memoryStream = new MemoryStream(response, 0, response.Length);
            memoryStream.Write(response, 0, response.Length);
            Image image = Image.FromStream(memoryStream, true);
            return image;
        }
        catch
        {
            throw new InvalidOperationException();
        }
    }

    public static void DeleteImage(string imagePath)
    {
        File.Delete(imagePath);
    }

    private static byte[] DecodeUrlBase64(string base64String) =>
        Convert.FromBase64String(base64String[(base64String.LastIndexOf(',') + 1)..]);
}