using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IQuery<out T> where T : DbContext
  {
    /// <summary>
    /// Reference to the EF Core DbContext class allowed to use in the query
    /// </summary>
    /// <value></value>
    T DataContext { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    dynamic Data { get; }

    /// <summary>
    /// If the field is true, means the query can be executed, otherwise is not executed
    /// </summary>
    bool Executable { get; }

    /// <summary>
    /// Execute the query main logic body 
    /// </summary>
    void Execute();
  }
}
