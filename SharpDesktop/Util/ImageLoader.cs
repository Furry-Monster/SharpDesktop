using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SharpDesktop.Util;

/// <summary>
/// A class for loading images from file paths or web URLs.
/// </summary>
public static class ImageLoader
{
    /// <summary>
    /// Loads an image from a file path.
    /// </summary>
    /// <param name="resourceUri"> The file path of the image. </param>
    /// <returns> The loaded image. </returns>
    public static Bitmap LoadFromResource(Uri resourceUri)
    {
        return new Bitmap(AssetLoader.Open(resourceUri));
    }

    /// <summary>
    /// Loads an image from a web URL.
    /// </summary>
    /// <param name="url"> The URL of the image. </param>
    /// <returns> The loaded image. </returns>
    public static async Task<Bitmap?> LoadFromWeb(Uri url)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while downloading image '{url}' : {ex.Message}");
            return null;
        }
    }
}
