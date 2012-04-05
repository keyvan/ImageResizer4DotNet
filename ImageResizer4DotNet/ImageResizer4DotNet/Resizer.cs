using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageResizer4DotNet
{
    public class Resizer
    {
        public static MemoryStream Resize(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            BitmapDecoder photoDecoder = BitmapDecoder.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            BitmapFrame photo = photoDecoder.Frames[0];

            TransformedBitmap target = new TransformedBitmap(
                photo,
                new ScaleTransform(
                    width / photo.Width * 96 / photo.DpiX,
                    height / photo.Height * 96 / photo.DpiY,
                    0, 0));
            BitmapFrame thumbnail = BitmapFrame.Create(target);
            BitmapFrame newphoto = Resize(thumbnail, width, height, BitmapScalingMode.Unspecified);

            PngBitmapEncoder targetEncoder = new PngBitmapEncoder();
            targetEncoder.Frames.Add(newphoto);
            targetEncoder.Save(result);

            return result;
        }

        public static MemoryStream Low(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            BitmapDecoder photoDecoder = BitmapDecoder.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            BitmapFrame photo = photoDecoder.Frames[0];

            TransformedBitmap target = new TransformedBitmap(
                photo,
                new ScaleTransform(
                    width / photo.Width * 96 / photo.DpiX,
                    height / photo.Height * 96 / photo.DpiY,
                    0, 0));
            BitmapFrame thumbnail = BitmapFrame.Create(target);
            BitmapFrame newphoto = Resize(thumbnail, width, height, BitmapScalingMode.LowQuality);

            PngBitmapEncoder targetEncoder = new PngBitmapEncoder();
            targetEncoder.Frames.Add(newphoto);
            targetEncoder.Save(result);

            return result;
        }


        public static MemoryStream High(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            BitmapDecoder photoDecoder = BitmapDecoder.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            BitmapFrame photo = photoDecoder.Frames[0];

            TransformedBitmap target = new TransformedBitmap(
                photo,
                new ScaleTransform(
                    width / photo.Width * 96 / photo.DpiX,
                    height / photo.Height * 96 / photo.DpiY,
                    0, 0));
            BitmapFrame thumbnail = BitmapFrame.Create(target);
            BitmapFrame newphoto = Resize(thumbnail, width, height, BitmapScalingMode.HighQuality);


            PngBitmapEncoder targetEncoder = new PngBitmapEncoder();
            targetEncoder.Frames.Add(newphoto);
            targetEncoder.Save(result);

            return result;
        }


        public static MemoryStream NearestNeighbor(MemoryStream original, int width, int height)
        {
            MemoryStream result = new MemoryStream();

            BitmapDecoder photoDecoder = BitmapDecoder.Create(original, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            BitmapFrame photo = photoDecoder.Frames[0];

            TransformedBitmap target = new TransformedBitmap(
                photo,
                new ScaleTransform(
                    width / photo.Width * 96 / photo.DpiX,
                    height / photo.Height * 96 / photo.DpiY,
                    0, 0));
            BitmapFrame thumbnail = BitmapFrame.Create(target);
            BitmapFrame newphoto = Resize(thumbnail, width, height, BitmapScalingMode.NearestNeighbor);


            PngBitmapEncoder targetEncoder = new PngBitmapEncoder();
            targetEncoder.Frames.Add(newphoto);
            targetEncoder.Save(result);

            return result;
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
    }
}
