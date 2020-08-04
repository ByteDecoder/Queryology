using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions
{
  /// <summary>
  /// QueryFactory interface contract.
  /// </summary>
  /// <typeparam name="T">DbContext type.</typeparam>
  public interface IQueryFactory<T>
    where T : DbContext
  {
    /// <summary>
    /// Creates a new instance of type IQuery.
    /// </summary>
    /// <param name="type">Query type.</param>
    /// <returns>Query instance.</returns>
    IQuery<T> Create(Type type);
  }
}
