namespace ConvertToWebP;

using System;

using static ImageConverter;

public static class FolderHandler
{
    public static void ConvertFolderImagesToWebp(string inputFolderPath, string outputFolderPath, int quality = 80)
    {
        if (!Directory.Exists(inputFolderPath))
        {
            Console.WriteLine($"Input folder '{inputFolderPath}' does not exist.");
            return;
        }

        if (!Directory.Exists(outputFolderPath))
        {
            Directory.CreateDirectory(outputFolderPath);
        }

        string[] imageFiles =
        [
            .. Directory.GetFiles(inputFolderPath, "*.jpg"),
            .. Directory.GetFiles(inputFolderPath, "*.jpeg"),
            .. Directory.GetFiles(inputFolderPath, "*.png"),
            .. Directory.GetFiles(inputFolderPath, "*.bmp"),
        ];

        foreach (string inputFile in imageFiles)
        {
            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            string outputFile = Path.Combine(outputFolderPath, $"{fileName}.webp");

            ConvertToWebp(inputFile, outputFile, quality);
            Console.WriteLine($"Converted {inputFile} to {outputFile}");
        }
    }
}
