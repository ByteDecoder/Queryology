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
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryologyEngineBuilder<T> AddObjectDumper<T>(
        this IQueryologyEngineBuilder<T> queryologyEngineBuilder) where T : DbContext
    {
        ArgumentNullException.ThrowIfNull(queryologyEngineBuilder, nameof(queryologyEngineBuilder));

        queryologyEngineBuilder.Configure(options =>
        {
            options.ObjectDisplayerProvider = ObjectDumperDisplayer.DisplayData;
        });

        return queryologyEngineBuilder;
    }
}
