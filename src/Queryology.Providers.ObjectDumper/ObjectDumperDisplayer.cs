namespace ByteDecoder.Queryology.Providers.ObjectDumper;

/// <summary>
///
/// </summary>
public static class ObjectDumperDisplayer
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="title"></param>
    /// <param name="data"></param>
    /// <param name="depth"></param>
    public static void DisplayData(string title, object data, int depth)
    {
        Console.WriteLine();
        Console.WriteLine(title);
        ObjectDumper.Write(data, depth);
        Console.WriteLine();
    }
}

