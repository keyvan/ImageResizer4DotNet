using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ImageResizer4DotNet
{
    public class Resizer
    {
        public static MemoryStream LowResize(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            Image image = Image.FromStream(original);

            // Don't do this to yourself!
            Image thumbnail = image.GetThumbnailImage(width, height, null, IntPtr.Zero);
            thumbnail.Save(result, image.RawFormat);

            thumbnail.Dispose();
            image.Dispose();

            result.Position = 0;

            return result;
        }

        public static MemoryStream MediumResize(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            Image image = Image.FromStream(original);
            Bitmap bitmap = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            Rectangle imageRectangle = new Rectangle(0, 0, width, height);
            graphics.DrawImage(image, imageRectangle);

            bitmap.Save(result, image.RawFormat);

            graphics.Dispose();
            bitmap.Dispose();
            image.Dispose();

            result.Position = 0;

            return result;
        }

        public static MemoryStream HighResize(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            Image image = Image.FromStream(original);
            Image thumbnail = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(thumbnail);

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            graphics.DrawImage(image, 0, 0, width, height);

            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            thumbnail.Save(result, info[1], encoderParameters);

            result.Position = 0;

            return result;
        }
    }
}
