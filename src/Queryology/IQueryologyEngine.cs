using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// QueryologyEngine base contract
  /// </summary>
  public interface IQueryologyEngine<T> where T : DbContext
  {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ignoreQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns></returns>
    QueryologyEngine<T> IgnoreExcludedQueries(bool ignoreQueries);

    /// <summary>
    /// Execution contract for all queries registered
    /// </summary>
    /// <returns>Total executed queries</returns>
    int Execute();
  }
}