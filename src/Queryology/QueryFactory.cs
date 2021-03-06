using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
    /// <summary>
    ///
    /// </summary>
    public class QueryFactory<T> : IQueryFactory<T> where T : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IQuery<T> Create(Type type)
        {
            return (IQuery<T>)Activator.CreateInstance(type);
        }
    }
}
