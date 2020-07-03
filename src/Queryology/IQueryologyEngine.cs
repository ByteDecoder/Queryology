namespace ByteDecoder.Queryology
{
  /// <summary>
  /// QueryologyEngine base contract
  /// </summary>
  public interface IQueryologyEngine
  {
    /// <summary>
    /// Execution contract for all queries registered
    /// </summary>
    /// <param name="ignoreExcludedQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns>Total executed queries</returns>
    int Execute(bool ignoreExcludedQueries);
  }
}