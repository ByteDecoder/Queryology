using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Providers.ObjectDumper;

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
    public static IQueryologyEngineBuilder<T> AddObjectDumper<T>(
        this IQueryologyEngineBuilder<T> queryologyEngineBuilder,
        T dbContext) where T : DbContext
    {
        ArgumentNullException.ThrowIfNull(queryologyEngineBuilder, nameof(queryologyEngineBuilder));
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

        queryologyEngineBuilder.Configure(options =>
        {
            options.DataContextProvider = dbContext;
            options.ObjectDisplayerProvider = new ObjectDumperDisplayer().DisplayData;
        });

        return queryologyEngineBuilder;
    }
}
