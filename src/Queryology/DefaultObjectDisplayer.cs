using System;
using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  public class DefaultObjectDisplayer : IObjectDisplayer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="data"></param>
    /// <param name="depth"></param>
    public void DisplayData(string title, object data, int depth)
    {
      Console.WriteLine($"{title} - {data.ToString()} - {depth}");
    }
  }
}