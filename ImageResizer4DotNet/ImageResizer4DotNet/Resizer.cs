using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageResizer4DotNet
{
    public partial class Resizer
    {
        public static MemoryStream ResizePng(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.Unspecified);

            return GetPngStream(newphoto);
        }

        public static MemoryStream LowPng(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.LowQuality);

            return GetPngStream(newphoto);
        }

        public static MemoryStream HighPng(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.HighQuality);

            return GetPngStream(newphoto);
        }

        public static MemoryStream NearestNeighborPng(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.NearestNeighbor);

            return GetPngStream(newphoto);
        }

        public static MemoryStream ResizeJpeg(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.Unspecified);

            return GetJpegStream(newphoto);
        }

        public static MemoryStream LowJpeg(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.LowQuality);

            return GetJpegStream(newphoto);
        }

        public static MemoryStream HighJpeg(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.HighQuality);

            return GetJpegStream(newphoto);
        }

        public static MemoryStream NearestNeighborJpeg(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.NearestNeighbor);

            return GetJpegStream(newphoto);
        }

        public static MemoryStream ResizeBmp(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.Unspecified);

            return GetBmpStream(newphoto);
        }

        public static MemoryStream LowBmp(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.LowQuality);

            return GetBmpStream(newphoto);
        }

        public static MemoryStream HighBmp(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.HighQuality);

            return GetBmpStream(newphoto);
        }

        public static MemoryStream NearestNeighborBmp(MemoryStream original, int width, int height)
        {
            BitmapFrame newphoto = GetBitmapFrame(original, width, height, BitmapScalingMode.NearestNeighbor);

            return GetBmpStream(newphoto);
        }
    }
}
