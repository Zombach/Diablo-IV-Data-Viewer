using System.Diagnostics;
using FFMpegCore;

namespace DiabloDataReader.VideoConverter;

public class Bk2J
{
    private readonly List<FileInfo> _files;
    public Bk2J(IEnumerable<FileInfo> files) => _files = files.ToList();

    public void Convert()
    {
        foreach (FileInfo fileInfo in _files)
        {
            IMediaAnalysis mediaInfo = FFProbe.Analyse(fileInfo.FullName, new FFOptions { BinaryFolder = ".\\Tools" } );
            Console.WriteLine("Обнаружен видео файл.");
            Console.WriteLine($"FormatName: {mediaInfo.Format.FormatLongName}");
            Console.WriteLine($"BitRate: {mediaInfo.Format.BitRate}");
            Console.WriteLine($"CodecTag: {mediaInfo.PrimaryVideoStream?.CodecTag}");
            Console.WriteLine($"CodecTagName: {mediaInfo.PrimaryVideoStream?.CodecTagString}");
            Console.WriteLine($"Width: {mediaInfo.PrimaryVideoStream?.Width}");
            Console.WriteLine($"Height: {mediaInfo.PrimaryVideoStream?.Height}");
            Console.WriteLine($"FrameRate: {mediaInfo.PrimaryVideoStream?.FrameRate}");
            Console.WriteLine($"Duration: {mediaInfo.Format.Duration}");

            bool isConvert;
            do
            {
                Console.WriteLine("Конвертировать видео? Y/N|У/Н?");
                string line = Console.ReadLine()?.ToLower() ?? string.Empty;
                if (line is "y" or "у" or "н" or "n")
                {
                    isConvert = line is "y" or "у";
                    break;
                }

                Console.WriteLine("Повторите ввод: Y/N|У/Н?");
            } while (true);

            if (isConvert)
            {
                if (!Directory.Exists("TmpVideo"))
                { Directory.CreateDirectory("TmpVideo"); }

                string newPath = $"TmpVideo\\{fileInfo.Name.Replace(fileInfo.Extension, ".bk2")}";
                File.Copy(fileInfo.FullName, newPath);
                Start(newPath);
            }
        }
    }

    private void Start(string path)
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            Verb = "runas",
            FileName = ".\\Tools\\radvideo64.exe",
            Arguments = $"BinkConv {path} {path.Replace(".bk2", ".mp4")} /o /#",
            WindowStyle = ProcessWindowStyle.Minimized
        };
        process.StartInfo = startInfo;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        string err = process.StandardError.ReadToEnd();
        Console.WriteLine(err);
        process.WaitForExit();// Waits here for the process to exit.
    }
}