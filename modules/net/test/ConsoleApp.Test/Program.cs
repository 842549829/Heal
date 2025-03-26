
using ConsoleApp.Test;

var imageProcessor = new SlideCaptchaGenerator();

// 原始背景图片路径
var background = "C:\\Users\\Administrator\\Desktop\\1742868256983.png";

// 拆分图片
var (backgroundImagePath, sliderImagePath, sliderPositionX, sliderPositionY) =
    imageProcessor.GenerateSlideCaptcha(background, sliderWidth: 50, sliderHeight: 50);

Console.WriteLine($"背景图路径: {backgroundImagePath}");
Console.WriteLine($"滑动图路径: {sliderImagePath}");
Console.WriteLine($"滑动图 X 坐标: {sliderPositionX}");
Console.WriteLine($"滑动图 Y 坐标: {sliderPositionY}");