using DiabloDataReader;
using DiabloDataReader.VideoConverter;
using DiabloIVDataReader.StlFiles;

ArgumentsHandler argumentsHandler = new(args);
argumentsHandler.Start();
if (argumentsHandler.IsClose) { return; }

List<FileInfo> files = argumentsHandler[FileFormatEnum.Unknown];
if (files.Count > 0)
{
    Console.WriteLine($"Будут пропущены {files.Count} файлов, ещё не научился с ними работать.");
    files.ForEach(fileInfo => Console.WriteLine($"Файл: {fileInfo.Name}"));
}

files = argumentsHandler[FileFormatEnum.Vid];
if (files.Count > 0)
{
    Bk2J bk2J = new(files);
    bk2J.Convert();
}


files = argumentsHandler[FileFormatEnum.Stl];
if (files.Count > 0)
{
    JsonConverter jsonConverter = new();
    Io io = new();
    foreach (FileInfo fileInfo in files)
    {
        Console.WriteLine($"File: {fileInfo.Name}");
        StlBytes bytes = new(File.ReadAllBytes(fileInfo.FullName));
        Stl stlFile = new(bytes);
        stlFile.GetInfo();
        string json = jsonConverter.Serialize(stlFile.Blocks);
        Console.WriteLine(json);
        io.Writer(fileInfo.Name.Replace(".stl", ".json", StringComparison.OrdinalIgnoreCase), json);
        Console.WriteLine();
    }
}
Console.ReadKey();