using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IQuery<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    T DataContext { get; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    dynamic Data { get; }

    /// <summary>
    /// 
    /// </summary>
    void Execute();
  }
}
