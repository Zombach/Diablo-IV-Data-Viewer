using DiabloDataReader;

if (args.Length is 0)
{
    Console.WriteLine("Укажите путь к файлу");
    return;
}

List<string> arguments = args.Where(argument => File.Exists(argument) && argument.EndsWith(".stl", StringComparison.OrdinalIgnoreCase)).ToList();
if (arguments.Count is 0)
{
    Console.WriteLine("Указаны не правильные пути файлов");
    return;
}
foreach (string path in arguments)
{
    Console.WriteLine($"File: {path}");
    BytesHandler bytes = new(File.ReadAllBytes(path));
    Stl stl = new(bytes);
    stl.GetInfo();
    foreach ((string key, string value) in stl.Blocks)
    {
        Console.WriteLine($"{key}\t{value}");
    }

    Console.WriteLine();
}

Console.ReadKey();