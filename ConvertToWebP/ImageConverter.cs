using ImageMagick;

public static class ImageConverter
{
    public static void ConvertToWebp(string inputFilePath, string outputFilePath, int quality = 80)
    {
        try
        {
            using MagickImage image = new(inputFilePath);
            image.Write(outputFilePath, MagickFormat.WebP);
        }
        catch (MagickException ex)
        {
            Console.WriteLine($"Error converting image: {ex.Message}");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}