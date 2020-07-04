using System;
using ByteDecoder.Queryology.Utils;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class QueryBase<T>: IQuery<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public dynamic Data { get; protected set; }

    /// <summary>
    /// Reference to the EF Core DbContext class allowed to use in the query
    /// </summary>
    /// <value></value>
    public T DataContext { get; private set; }

    /// <summary>
    /// If the field is true, means the query can be executed, otherwise is not executed
    /// </summary>
    public virtual bool Executable => true;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext"></param>
    protected QueryBase(T dataContext) => DataContext = dataContext;

    /// <summary>
    /// Execute the query main logic body 
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">Message to label the query execution</param>
    /// <param name="depth">Level of depth for object exploration</param>
    protected void DisplayData(string title, int depth = 1)
    {
      Console.WriteLine();
      Console.WriteLine(title);
      ObjectDumper.Write(Data, depth);
      Console.WriteLine();
    }
  }
}
