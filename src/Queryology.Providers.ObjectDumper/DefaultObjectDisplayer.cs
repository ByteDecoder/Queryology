using System;
using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Providers.ObjectDumper
{
  public class DefaultObjectDisplayer : IObjectDisplayer
  {
    public void DisplayData(string title, object data, int depth)
    {
      Console.WriteLine();
      Console.WriteLine(title);
      ObjectDumper.Write(data, depth);
      Console.WriteLine();
    }
  }
}
