using csv.convert.console;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
           .AddSingleton<IConvertSelector, ConvertSelector>()
           .BuildServiceProvider();

FileBase fileCsvToJson = new FileBase { NameFile = "json 20", 
                                        Path = @"C:\Users\nstay\source\repos\csv.convert\csv.convert\upload\city.csv", 
                                        MimeType = MimeTypeFileEnum.Json
                                        };

Console.WriteLine(serviceProvider.GetService<IConvertSelector>()
            .SelectConverter(fileCsvToJson.MimeType)
            .Convert(fileCsvToJson));
