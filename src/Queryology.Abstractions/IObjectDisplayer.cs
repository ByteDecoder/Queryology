namespace ByteDecoder.Queryology.Abstractions
{
  /// <summary>
  /// 
  /// </summary>
  public interface IObjectDisplayer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="data"></param>
    /// <param name="depth"></param>
    void DisplayData(string title, object data, int depth);
  }
}
