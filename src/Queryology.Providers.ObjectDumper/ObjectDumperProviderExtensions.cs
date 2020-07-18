using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Providers.ObjectDumper
{
  /// <summary>
  /// 
  /// </summary>
  public static class ObjectDumperProviderExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryologyEngineBuilder"></param>
    /// <param name="dbContext"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryologyEngineBuilder<T> AddObjectDumper<T>(this IQueryologyEngineBuilder<T> queryologyEngineBuilder, T dbContext)
        where T : DbContext
    {
      if (queryologyEngineBuilder is null)
        throw new ArgumentNullException(nameof(queryologyEngineBuilder));

      if (dbContext == null)
        throw new ArgumentNullException(nameof(dbContext));

      queryologyEngineBuilder.Configure(options =>
      {
        options.DataContextProvider = dbContext;
        options.ObjectDisplayerProvider = new ObjectDumperDisplayer();
      });

      return queryologyEngineBuilder;
    }
  }
}
