using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Providers.ObjectDumper
{
  public static class ObjectDumperProviderExtensions
  {
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
