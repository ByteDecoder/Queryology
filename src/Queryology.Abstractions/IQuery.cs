using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions
{
    /// <summary>
    /// Describes the contract for IQuery.
    /// </summary>
    /// <typeparam name="T">DbContext Type.</typeparam>
    public interface IQuery<T>
        where T : DbContext
    {
        /// <summary>
        /// Gets or sets the reference to the EF Core DbContext class allowed to use in the query.
        /// </summary>
        /// <value>DbContext.</value>
        T DataContext { get; set; }

        /// <summary>
        /// Gets the data object processed.
        /// </summary>
        /// <value>Data object.</value>
        dynamic Data { get; }

        /// <summary>
        /// Gets a value indicating whether gets if the query can be executed.
        /// </summary>
        bool Executable { get; }

        /// <summary>
        /// Gets or sets the IObjectDisplayer.
        /// </summary>
        IObjectDisplayer ObjectDisplayer { get; set; }

        /// <summary>
        /// Execute the query main logic body.
        /// </summary>
        void Execute();
    }
}
