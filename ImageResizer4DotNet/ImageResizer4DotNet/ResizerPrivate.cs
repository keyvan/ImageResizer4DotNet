using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageResizer4DotNet
{
    public partial class Resizer
    {
        private static BitmapFrame GetBitmapFrame(MemoryStream original, int width, int height, BitmapScalingMode mode)
        {
            BitmapDecoder photoDecoder = BitmapDecoder.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            BitmapFrame photo = photoDecoder.Frames[0];

            TransformedBitmap target = new TransformedBitmap(
                photo,
                new ScaleTransform(
                    width / photo.Width * 96 / photo.DpiX,
                    height / photo.Height * 96 / photo.DpiY,
                    0, 0));
            BitmapFrame thumbnail = BitmapFrame.Create(target);
            BitmapFrame newPhoto = Resize(thumbnail, width, height, mode);

            return newPhoto;
        }

        private static BitmapFrame Resize(BitmapFrame photo, int width, int height, BitmapScalingMode scalingMode)
        {
            DrawingGroup group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, scalingMode);
            group.Children.Add(new ImageDrawing(photo, new Rect(0, 0, width, height)));
            DrawingVisual targetVisual = new DrawingVisual();
            DrawingContext targetContext = targetVisual.RenderOpen();
            targetContext.DrawDrawing(group);
            RenderTargetBitmap target = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            targetContext.Close();
            target.Render(targetVisual);
            BitmapFrame targetFrame = BitmapFrame.Create(target);
            return targetFrame;
        }

        private static MemoryStream GetPngStream(BitmapFrame photo)
        {
            MemoryStream result = new MemoryStream();

            PngBitmapEncoder targetEncoder = new PngBitmapEncoder();
            targetEncoder.Frames.Add(photo);
            targetEncoder.Save(result);

            return result;
        }

        private static MemoryStream GetJpegStream(BitmapFrame photo)
        {
            MemoryStream result = new MemoryStream();

            JpegBitmapEncoder targetEncoder = new JpegBitmapEncoder();
            targetEncoder.Frames.Add(photo);
            targetEncoder.Save(result);

            return result;
        }

        private static MemoryStream GetBmpStream(BitmapFrame photo)
        {
            MemoryStream result = new MemoryStream();

            BmpBitmapEncoder targetEncoder = new BmpBitmapEncoder();
            targetEncoder.Frames.Add(photo);
            targetEncoder.Save(result);

            return result;
        }
    }
}
