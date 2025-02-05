using ImageConsoleApp;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

var switchMappings = new Dictionary<string, string>
{
	{"--thumbnailWidth", "thumbnail:width" },
	{"-cl", "compressionLevel" }
};

IConfigurationRoot configuration = new ConfigurationBuilder()
									.AddJsonFile("config.json")
									.AddCommandLine(args, switchMappings)
									.Build();

Console.WriteLine("***** Process Image *****");
Console.WriteLine($"Processing {args[0]}");

ImageConfig imageConfig = configuration.GetSection(nameof(ImageConfig)).Get<ImageConfig>();


ProcessImage("Thumbnail", imageConfig.Thumbnail, imageConfig.CompressionLevel);
ProcessImage("Medium", imageConfig.Medium, imageConfig.CompressionLevel);
ProcessImage("Large", imageConfig.Large, imageConfig.CompressionLevel);

static void ProcessImage(string imageSize, ImageSizeConfig config, decimal compressionLevel)
{
	Console.WriteLine($"{imageSize} Width: {config.Width}");
	Console.WriteLine($"{imageSize} FilePrefix: {config.FilePrefix}");
	Console.WriteLine($"{imageSize} WaterMark: {config.WatermarkText}");
	Console.WriteLine($"{imageSize} Compression Level: {compressionLevel}");
}