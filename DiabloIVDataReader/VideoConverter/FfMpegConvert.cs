using FFMpegCore.Pipes;
using FFMpegCore;
using System.IO;
using FFMpegCore.Enums;

namespace DiabloDataReader.VideoConverter;

public class FfMpegConvert
{
    public void Start(string path)
    {
        var mediaInfo = FFProbe.Analyse(path);
        try
        {
            FFMpeg.Convert(path, path.Replace("vid", "mp4"), VideoType.Mp4, Speed.Fast, VideoSize.Original,
                AudioQuality.Ultra);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
           
        }
        
    }
}