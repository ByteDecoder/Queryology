using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.Queryology;
using Microsoft.EntityFrameworkCore;

namespace Queryology.Extensions
{
  /// <summary>
  /// IQuery LINQ query operator extensions
  /// </summary>
  public static class QueryExtensions
  {
    /// <summary>
    /// LINQ deferred query operator to filter the query execution if queries are Executable or ignore that object state
    /// </summary>
    /// <param name="source">source enuemrable sequence</param>
    /// <param name="ignoreExcludedQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns>Sequence affected after applying the query operator</returns>
    public static IEnumerable<IQuery<T>> AllowedQueries<T>(this IEnumerable<IQuery<T>> source, bool ignoreExcludedQueries = true)
      where T : DbContext
    {
      if (source == null) throw new ArgumentNullException(nameof(source));

      if (ignoreExcludedQueries)
        source = source.Where(query => query.Executable);

      return source;
    }
  }
}