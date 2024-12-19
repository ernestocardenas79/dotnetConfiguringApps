﻿using Microsoft.Extensions.Configuration;
using System;


IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("config.json");

IConfigurationRoot configuration = configurationBuilder.Build();

Console.WriteLine("***** Process Image *****");
Console.WriteLine($"Processing {args[0]}");

Console.WriteLine($"Thumbnail Width: {configuration["THUMBNAILWIDTH"]}");
Console.WriteLine($"Thumbnail FilePrefix: {configuration["thumbnailFilePrefix"]}");

Console.WriteLine($"Medium Width: {configuration["mediumWidth"]}");
Console.WriteLine($"Medium FilePrefix: {configuration["mediumFilePrefix"]}");

Console.WriteLine($"Large Width: {configuration["largeWidth"]}");
Console.WriteLine($"Large FilePrefix: {configuration["largeFilePrefix"]}");

Console.WriteLine($"Watermark: {configuration["watermarkText"]}");

Console.WriteLine($"Compression Level: {configuration["compressionLevel"]}");
