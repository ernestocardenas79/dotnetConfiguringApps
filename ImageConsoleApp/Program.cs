using System;

Console.WriteLine("Hello World!");
IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("config.json");

IConfigurationRoot configuration = configurationBuilder.Build();

Console.WriteLine("***** Process Image *****");
Console.WriteLine($"Processing {args[0]}");
