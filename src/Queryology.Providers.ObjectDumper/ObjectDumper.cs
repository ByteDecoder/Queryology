//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace ByteDecoder.Queryology.Providers.ObjectDumper
{
  /// <summary>
  /// 
  /// </summary>
  public partial class ObjectDumper
  {
    #region static public methods
    ///
    public static void Write(object element)
    {
      Write(element, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <param name="depth"></param>
    public static void Write(object element, int depth)
    {
      Write(element, depth, Console.Out);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <param name="depth"></param>
    /// <param name="log"></param>
    public static void Write(object element, int depth, TextWriter log)
    {
      ObjectDumper dumper = new ObjectDumper(depth);
      dumper.writer = log;
      dumper.WriteObject(null, element);
    }

    #endregion

    private TextWriter writer;
    private int pos;
    private int level;
    private int depth;

    private ObjectDumper(int depth)
    {
      this.depth = depth;
    }

    private void Write(string s)
    {
      if (s != null)
      {
        writer.Write(s);
        pos += s.Length;
      }
    }

    private void WriteIndent()
    {
      for (int i = 0; i < level; i++) writer.Write("  ");
    }

    private void WriteLine()
    {
      writer.WriteLine();
      pos = 0;
    }

    private void WriteTab()
    {
      Write("  ");
      while (pos % 8 != 0) Write(" ");
    }

    private bool IsBasicType(object element) => element == null || element is ValueType || element is string;

    private void WriteObject(string prefix, object element)
    {
      if (IsBasicType(element))
      {
        WriteBasicType(element, prefix);
      }
      else
      {
        IEnumerable enumerableElement = element as IEnumerable;
        if (enumerableElement != null)
        {
          WriteEnumerable(enumerableElement, prefix);
        }
        else
        {
          MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
          WriteIndent();
          Write(prefix);
          bool propWritten = false;
          foreach (MemberInfo m in members)
          {
            FieldInfo f = m as FieldInfo;
            PropertyInfo p = m as PropertyInfo;
            if (f != null || p != null)
            {
              if (propWritten)
              {
                WriteTab();
              }
              else
              {
                propWritten = true;
              }

              Write(m.Name);
              Write("=");
              Type t = f != null ? f.FieldType : p.PropertyType;
              if (t.IsValueType || t == typeof(string))
              {
                WriteValue(f != null ? f.GetValue(element) : p.GetValue(element, null));
              }
              else
              {
                if (typeof(IEnumerable).IsAssignableFrom(t))
                {
                  Write("...");
                }
                else
                {
                  Write("{ }");
                }
              }
            }
          }

          if (propWritten) WriteLine();
          if (level < depth)
          {
            foreach (MemberInfo m in members)
            {
              FieldInfo f = m as FieldInfo;
              PropertyInfo p = m as PropertyInfo;
              if (f != null || p != null)
              {
                Type t = f != null ? f.FieldType : p.PropertyType;
                if (!(t.IsValueType || t == typeof(string)))
                {
                  object value = f != null ? f.GetValue(element) : p.GetValue(element, null);
                  if (value != null)
                  {
                    level++;
                    WriteObject(m.Name + ": ", value);
                    level--;
                  }
                }
              }
            }
          }
        }
      }
    }

    private void WriteBasicType(object element, string prefix)
    {
      WriteIndent();
      Write(prefix);
      WriteValue(element);
      WriteLine();
    }

    private void WriteEnumerable(IEnumerable enumerableElement, string prefix)
    {
      foreach (object item in enumerableElement)
      {
        if (item is IEnumerable && !(item is string))
        {
          WriteIndent();
          Write(prefix);
          Write("...");
          WriteLine();
          if (level < depth)
          {
            level++;
            WriteObject(prefix, item);
            level--;
          }
        }
        else
        {
          WriteObject(prefix, item);
        }
      }
    }

    private void WriteValue(object o)
    {
      if (o == null)
      {
        Write("null");
      }
      else if (o is DateTime)
      {
        Write(((DateTime)o).ToShortDateString());
      }
      else if (o is ValueType || o is string)
      {
        Write(o.ToString());
      }
      else if (o is IEnumerable)
      {
        Write("...");
      }
      else
      {
        Write("{ }");
      }
    }
  }
}
