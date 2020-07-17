using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class QueryBase<T> : IQuery<T> where T : DbContext
  {
    private readonly IObjectDisplayer _objectDisplayer;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public dynamic Data { get; protected set; }

    /// <summary>
    /// Reference to the EF Core DbContext class allowed to use in the query
    /// </summary>
    /// <value></value>
    public T DataContext { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IObjectDisplayer ObjectDisplayer { get; set; }

    /// <summary>
    /// If the field is true, means the query can be executed, otherwise is not executed
    /// </summary>
    public virtual bool Executable => true;

    /// <summary>
    /// 
    /// </summary>
    protected QueryBase() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext"></param>
    protected QueryBase(T dataContext)
    {
      DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext"></param>
    /// <param name="objectDisplayer"></param>
    protected QueryBase(T dataContext, IObjectDisplayer objectDisplayer) : this(dataContext)
    {
      _objectDisplayer = objectDisplayer ?? throw new ArgumentNullException(nameof(dataContext));
    }

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
      _objectDisplayer.DisplayData(title, Data, depth);
    }
  }
}
