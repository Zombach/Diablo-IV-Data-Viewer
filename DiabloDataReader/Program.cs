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

JsonConverter jsonConverter = new();
Io io = new();
foreach (string path in arguments)
{
    Console.WriteLine($"File: {path}");
    BytesStl bytes = new(File.ReadAllBytes(path));
    Stl stl = new(bytes);
    stl.GetInfo();
    string json = jsonConverter.Serialize(stl.Blocks);
    Console.WriteLine(json);
    io.Writer(path.Replace(".stl", ".json", StringComparison.OrdinalIgnoreCase), json);
    Console.WriteLine();
}

Console.ReadKey();