using System;
using ByteDecoder.Queryology.Utils;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class QueryBase<T> : IQuery<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public dynamic Data { get; protected set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public T DataContext { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual bool Executable => true;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext"></param>
    protected QueryBase(T dataContext)
    {
      DataContext = dataContext;
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="depth"></param>
    protected void DisplayData(string title, int depth = 1)
    {
      Console.WriteLine();
      Console.WriteLine(title);
      if (Data != null) ObjectDumper.Write(Data, depth);
      Console.WriteLine();
    }

  }
}
