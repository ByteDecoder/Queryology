using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Providers;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueryBase<T> : IQuery<T>
      where T : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBase{T}"/> class.
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="objectDisplayer"></param>
        protected QueryBase(T dataContext, DisplayObjectData objectDisplayer)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            ObjectDisplayer = objectDisplayer ?? throw new ArgumentNullException(nameof(objectDisplayer));
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public object Data { get; protected set; } = new();

        /// <summary>
        /// Reference to the EF Core DbContext class allowed to use in the query.
        /// </summary>
        /// <value></value>
        public T DataContext { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DisplayObjectData ObjectDisplayer { get; set; } = NullObjectDisplayer.DisplayData;

        /// <summary>
        /// If the field is true, means the query can be executed, otherwise is not executed.
        /// </summary>
        public virtual bool Executable => true;

        /// <summary>
        /// Execute the query main logic body.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        ///
        /// </summary>
        /// <param name="title">Message to label the query execution.</param>
        /// <param name="depth">Level of depth for object exploration.</param>
        protected void DisplayData(string title, int depth = 1) =>
            ObjectDisplayer(title, Data, depth);
    }
}
