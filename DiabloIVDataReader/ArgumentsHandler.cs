using System.IO;

namespace DiabloDataReader;

public class ArgumentsHandler
{
    private readonly Dictionary<FileFormatEnum, List<FileInfo>> _dictionary;
    public List<FileInfo> this[FileFormatEnum formatEnum] => _dictionary[formatEnum];


    private readonly List<string> _arguments;
    private bool _isClose;
    public bool IsClose => _isClose;

    public ArgumentsHandler(IEnumerable<string> arguments)
    {
        _isClose = false;
        _arguments = arguments.ToList();
        _dictionary = new();
        Enum.GetValues<FileFormatEnum>().ToList()
        .ForEach(key => _dictionary.Add(key, new List<FileInfo>(0)));
    }

    public void Start()
    {
        foreach (string argument in _arguments)
        {
            if (!File.Exists(argument))
            {
                Console.WriteLine("В данный момент, доступна работа с файлами. Остальные возможности будут в следующих версиях");
                _isClose = true;
                return;
            }

            FileInfo fileInfo = new FileInfo(argument);
            FileFormatEnum formatEnum = GetFormat(ref fileInfo);
            AddFileInfo(formatEnum, fileInfo);
        }
    }

    private FileFormatEnum GetFormat(ref FileInfo fileInfo) => Enum.TryParse(fileInfo.Extension.Replace(".", string.Empty), true, out FileFormatEnum format) ? format : FileFormatEnum.Unknown;   

    private void AddFileInfo(FileFormatEnum key, FileInfo fileInfo) => _dictionary[key].Add(fileInfo);
}