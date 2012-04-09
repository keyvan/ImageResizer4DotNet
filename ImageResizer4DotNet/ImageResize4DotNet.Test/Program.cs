using System;
using System.IO;
using ImageResizer4DotNet;

namespace ImageResize4DotNet.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Image Resizer for .NET";

            string filePath = @"C:\Users\Keyvan Nayyeri\Documents\Git\ImageResizer4DotNet\ImageResizer4DotNet\ImageResize4DotNet.Test\Original.jpg";

            Console.WriteLine("Enter the original image path:");
            string temp = Console.ReadLine();

            if (!string.IsNullOrEmpty(temp))
                filePath = temp;

            // Low quality PNG
            MemoryStream original = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
            MemoryStream resizedStreamLow = Resizer.LowPng(original, 400, 225);
            File.WriteAllBytes("resizedlow.png", resizedStreamLow.ToArray());

            // Low quality JPEG
            original = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
            resizedStreamLow = Resizer.LowJpeg(original, 400, 225);
            File.WriteAllBytes("resizedlow.jpg", resizedStreamLow.ToArray());

            // Low quality BMP
            original = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
            resizedStreamLow = Resizer.LowBmp(original, 400, 225);
            File.WriteAllBytes("resizedlow.bmp", resizedStreamLow.ToArray());

            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}
