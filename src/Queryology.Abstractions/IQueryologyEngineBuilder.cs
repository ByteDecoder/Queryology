using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryologyEngineBuilder<T> where T : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryologyEngineOptions"></param>
        /// <returns></returns>
        IQueryologyEngineBuilder<T> Configure(Action<QueryologyEngineOptions<T>> queryologyEngineOptions);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryologyEngine<T> Build();
    }
}
