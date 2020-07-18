using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Tests.Support
{
  public class TestObjectViewer: IObjectDisplayer
  {
    public void DisplayData(string title, object data, int depth)
    {
      // Just empty method for fast unit testing
    }
  }
}
