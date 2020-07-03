namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  public interface IQueryologyEngine
  {
    /// <summary>
    /// Execution contract for all queries registered
    /// </summary>
    /// <returns>Total executed queries</returns>
    int Execute();
  }
}