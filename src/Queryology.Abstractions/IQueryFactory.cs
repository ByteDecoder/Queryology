using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions
{
  /// <summary>
  /// 
  /// </summary>
  public interface IQueryFactory<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    IQuery<T> Create(Type type);
  }
}