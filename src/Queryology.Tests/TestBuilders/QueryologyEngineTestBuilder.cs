using System;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Tests.Support;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
    /// <summary>
    /// Represents a test builder for QueryologyEngine.
    /// </summary>
    /// <typeparam name="T">The type of the DbContext.</typeparam>
    internal class QueryologyEngineTestBuilder<T> : IDisposable
        where T : DbContext, new()
    {
        private T _dbContext;
        private IQueryologyEngine<T> _queryologyEngine;
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryologyEngineTestBuilder{T}"/> class.
        /// </summary>
        public QueryologyEngineTestBuilder()
        {
            _dbContext = new T();
            _queryologyEngine = new QueryologyEngineBuilder<T>().Configure(options =>
            {
                options.DataContextProvider = _dbContext;
                options.ObjectDisplayerProvider = TestObjectViewer.DisplayData;
            }).Build();
        }

        /// <summary>
        /// Specifies that excluded queries should not be ignored.
        /// </summary>
        /// <returns>The current instance of the <see cref="QueryologyEngineTestBuilder{T}"/>.</returns>
        public QueryologyEngineTestBuilder<T> NotIgnoreExcludedQueries()
        {
            _queryologyEngine.IgnoreExcludedQueries(false);
            return this;
        }

        /// <summary>
        /// Specifies that excluded queries should be ignored.
        /// </summary>
        /// <returns>The current instance of the <see cref="QueryologyEngineTestBuilder{T}"/>.</returns>
        public QueryologyEngineTestBuilder<T> IgnoreExcludedQueries()
        {
            _queryologyEngine.IgnoreExcludedQueries(true);
            return this;
        }

        /// <summary>
        /// Builds and returns an instance of the <see cref="IQueryologyEngine{T}"/>.
        /// </summary>
        /// <returns>An instance of the <see cref="IQueryologyEngine{T}"/>.</returns>
        public IQueryologyEngine<T> Build()
        {
            return _queryologyEngine;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True if called from the `Dispose` method, false if called from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _dbContext = null;
            _queryologyEngine = null;

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
