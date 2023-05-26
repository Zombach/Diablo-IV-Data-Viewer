namespace DiabloDataReader;

public class Io
{
    public void Writer(string path, string json)
    {
        using StreamWriter sw = new(path);
        sw.Write(json);
    }
}