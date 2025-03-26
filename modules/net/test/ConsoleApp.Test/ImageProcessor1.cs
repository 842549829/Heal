using SkiaSharp;

namespace ConsoleApp.Test;

public class ImageProcessor1
{
    private readonly Random _random = new Random();

    public (string BackgroundImagePath, string SliderImagePath, int SliderPositionX, int SliderPositionY) SplitImage(string backgroundImagePath, int sliderWidth = 50, int sliderHeight = 50)
    {
        using var backgroundStream = File.OpenRead(backgroundImagePath);
        using var backgroundBitmap = SKBitmap.Decode(backgroundStream);
        int backgroundWidth = backgroundBitmap.Width;
        int backgroundHeight = backgroundBitmap.Height;

        // 随机生成滑动图位置
        int sliderPositionX = _random.Next(50, backgroundWidth - sliderWidth - 50);
        int sliderPositionY = _random.Next(50, backgroundHeight - sliderHeight - 50);

        // 创建滑动图
        using var sliderBitmap = new SKBitmap(sliderWidth, sliderHeight);
        using (var sliderCanvas = new SKCanvas(sliderBitmap))
        {
            sliderCanvas.Clear(SKColors.Transparent);
            var sourceRect = new SKRectI(sliderPositionX, sliderPositionY, sliderPositionX + sliderWidth, sliderPositionY + sliderHeight);
            var destRect = new SKRect(0, 0, sliderWidth, sliderHeight);
            sliderCanvas.DrawBitmap(backgroundBitmap, sourceRect, destRect);
            AddRoundedCorners(sliderCanvas, sliderBitmap, 10); // 添加圆角
        }

        // 处理背景图的裁剪区域（透明带阴影）
        using (var backgroundCanvas = new SKCanvas(backgroundBitmap))
        {
            // 绘制阴影（模糊黑色矩形）
            var shadowPaint = new SKPaint
            {
                Color = new SKColor(0, 0, 0, 100), // 半透明黑色
                IsAntialias = true
            };

            // 创建模糊效果（使用 SKMaskFilter.CreateBlur）
            var blurFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 10); // 模糊半径为10
            shadowPaint.MaskFilter = blurFilter; // 赋值给 Paint 的 MaskFilter 属性

            // 阴影偏移量
            int shadowOffsetX = 5;
            int shadowOffsetY = 5;
            var shadowRect = new SKRect(
                sliderPositionX - shadowOffsetX,
                sliderPositionY - shadowOffsetY,
                sliderPositionX + sliderWidth + shadowOffsetX,
                sliderPositionY + sliderHeight + shadowOffsetY
            );
            backgroundCanvas.DrawRect(shadowRect, shadowPaint);

            // 设置裁剪区域为透明
            var clearPaint = new SKPaint();
            clearPaint.BlendMode = SKBlendMode.Clear;
            var clearRect = new SKRect(
                sliderPositionX,
                sliderPositionY,
                sliderPositionX + sliderWidth,
                sliderPositionY + sliderHeight
            );
            backgroundCanvas.DrawRect(clearRect, clearPaint);
        }

        // 保存图片
        string tempDirectory = Path.Combine(Path.GetTempPath(), "SlideCaptcha");
        Directory.CreateDirectory(tempDirectory);
        string backgroundFilePath = Path.Combine(tempDirectory, Guid.NewGuid().ToString() + ".png");
        string sliderFilePath = Path.Combine(tempDirectory, Guid.NewGuid().ToString() + ".png");
        SaveImageToFile(backgroundBitmap, backgroundFilePath);
        SaveImageToFile(sliderBitmap, sliderFilePath);

        return (backgroundFilePath, sliderFilePath, sliderPositionX, sliderPositionY);
    }

    // 添加圆角方法
    private void AddRoundedCorners(SKCanvas canvas, SKBitmap bitmap, int cornerRadius)
    {
        var paint = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };
        var path = new SKPath();
        path.AddRoundRect(new SKRect(0, 0, bitmap.Width, bitmap.Height), cornerRadius, cornerRadius);
        canvas.Save();
        canvas.ClipPath(path);
        canvas.DrawBitmap(bitmap, 0, 0);
        canvas.Restore();
    }

    // 保存图片方法
    private void SaveImageToFile(SKBitmap bitmap, string filePath)
    {
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = File.OpenWrite(filePath);
        data.SaveTo(stream);
    }
}