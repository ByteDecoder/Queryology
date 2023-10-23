using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions;

/// <summary>
/// Method for displaying the data. This delagate can be used for web, console,
/// files or other storages types to store the result.
/// </summary>
/// <param name="title"></param>
/// <param name="data"></param>
/// <param name="depth"></param>
public delegate void DisplayObjectData(string title, object data, int depth);

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
    object Data { get; }

    /// <summary>
    /// Gets a value indicating whether gets if the query can be executed.
    /// </summary>
    bool Executable { get; }

    /// <summary>
    /// Gets or sets the IObjectDisplayer.
    /// </summary>
    DisplayObjectData ObjectDisplayer { get; set; }

    /// <summary>
    /// Execute the query main logic body.
    /// </summary>
    void Execute();
}
