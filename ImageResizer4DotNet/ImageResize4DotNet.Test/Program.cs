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

            string filePath = @"c:\users\keyvan nayyeri\documents\visual studio 2010\Projects\ImageResizer4DotNet\ImageResize4DotNet.Test\Original.jpg";

            Console.WriteLine("Enter the original image path:");
            string temp = Console.ReadLine();

            if (!string.IsNullOrEmpty(temp))
                filePath = temp;

            MemoryStream original = new MemoryStream
                (System.IO.File.ReadAllBytes(filePath));

            MemoryStream resizedStream = Resizer.LowResize(original, 400, 225);

            StreamWriter writer = new StreamWriter("resized.jpg");
            resizedStream.WriteTo(writer.BaseStream);
            writer.Close();

            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}
