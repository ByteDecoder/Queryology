using System;
using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Providers
{
  /// <summary>
  /// 
  /// </summary>
  public sealed class NullObjectDisplayer : IObjectDisplayer
  {
    private static NullObjectDisplayer _instance;
    private static bool Initialised => _instance != null;

    private NullObjectDisplayer() { }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public static NullObjectDisplayer Instance
    {
      get
      {
        if (Initialised) return _instance;
        _instance = new NullObjectDisplayer();
        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="data"></param>
    /// <param name="depth"></param>
    public void DisplayData(string title, object data, int depth)
    {
      Console.WriteLine("Please use an ObjectDisplayer provider");
    }
  }
}