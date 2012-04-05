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

            // Low quality
            MemoryStream original = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
            MemoryStream resizedStreamLow = Resizer.Low(original, 400, 225);
            File.WriteAllBytes("resizedlow.png", resizedStreamLow.ToArray());
            resizedStreamLow.Position = 0;

            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}
