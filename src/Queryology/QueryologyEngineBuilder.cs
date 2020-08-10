using System;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Providers;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryologyEngineBuilder<T> : IQueryologyEngineBuilder<T> where T : DbContext
    {
        private IQueryologyEngine<T> _queryologyEngine;

        /// <summary>
        ///
        /// </summary>
        /// <param name="queryologyEngineOptions"></param>
        /// <returns></returns>
        public IQueryologyEngineBuilder<T> Configure(Action<QueryologyEngineOptions<T>> queryologyEngineOptions)
        {
            var options = new QueryologyEngineOptions<T>();
            queryologyEngineOptions(options);
            options.QueryFactoryProvider ??= new QueryFactory<T>();
            options.ObjectDisplayerProvider ??= NullObjectDisplayer.Instance;
            _queryologyEngine = new QueryologyEngine<T>(options);

            return this;
        }

        /// <summary>
        /// Build a Queryology Engine.
        /// </summary>
        /// <returns>QueryologyEngine</returns>
        public IQueryologyEngine<T> Build()
        {
            return _queryologyEngine;
        }
    }
}
