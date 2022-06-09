# csv.convert
C# OOP console application that can be given a CSV file and convert it to JSON or XML.
Was used the Strategy Design, Its main goal is to decouple the behavior of an object from 
its state by modeling the behavior into an abstraction which could have more than one 
implementation. And the 8 basic software engineering principles:
1. DRY - Don't Repeat Yourself
2. KISS - Keep It Simple Stupid
3. YAGNI - You Aren't Gonna Need It (avoid creating extra complexity through adding functionality
 that you assume you may need in the future)
SOLID:
4. Single Responsibility - every module or class should have only a single responsibility.
5. Open/Closed - software entities should be open for extension but closed for modification.
6. Liskov Substitution - objects in a program should be replaceable with instances of their subtypes without altering the 
correctness of that program.
7. Interface Segregation - small client-specific interfaces are better than one general-purpose interface.
8. Dependency Inversion - use interfaces instead of concrete implementations.

```csharp
csv.convert/Program.cs

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
```

![image](https://user-images.githubusercontent.com/4419209/172831470-7a4161ce-0190-4d7e-b0ab-96adfaf130e4.png)

![image](https://user-images.githubusercontent.com/4419209/172832043-e203dbfd-ee79-425d-b4b2-2a57eb4357c6.png)
Note: Json have an object "address" that was separated and grouped




```csv
csv.convert/upload/city.csv

name,address_line1,address_line2
Dave,Street,Town
Jhon,45,City
```
