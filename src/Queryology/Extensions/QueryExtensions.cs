using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Extensions
{
  /// <summary>
  /// IQuery LINQ query operator extensions
  /// </summary>
  public static class QueryExtensions
  {
    /// <summary>
    /// LINQ deferred query operator to filter the query execution if queries are Executable or ignore that object state
    /// </summary>
    /// <param name="source">source enumerable sequence</param>
    /// <param name="ignoreQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns>Sequence affected after applying the query operator</returns>
    public static IEnumerable<IQuery<T>> IgnoreExcludedQueries<T>(this IEnumerable<IQuery<T>> source, bool ignoreQueries = true)
      where T : DbContext
    {
      if(source == null) throw new ArgumentNullException(nameof(source));

      if(ignoreQueries)
        source = source.Where(query => query.Executable);

      return source;
    }
  }
}