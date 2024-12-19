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

IConfiguration thumbnailConfig = configuration.GetSection("thumbnail");
ProcessImage("Thumbnail", thumbnailConfig);;

IConfiguration mediumConfig = configuration.GetSection("medium");
ProcessImage("Medium", mediumConfig);

IConfiguration largeConfig = configuration.GetSection("large");
ProcessImage("Large", largeConfig);

Console.WriteLine($"Watermark: {configuration["watermarkText"]}");
Console.WriteLine($"Compression Level: {configuration["compressionLevel"]}");

static void ProcessImage(string imageSize, IConfiguration config)
{
	Console.WriteLine($"{imageSize} Width: {config["width"]}");
	Console.WriteLine($"{imageSize} FilePrefix: {config["filePrefix"]}");
}