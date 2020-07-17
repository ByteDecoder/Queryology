using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class QueryologyEngineOptions<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public T DataContextProvider { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public IObjectDisplayer ObjectDisplayerProvider { get; set; }
  }
}