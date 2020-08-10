// Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ByteDecoder.Queryology.Providers.ObjectDumper
{
  /// <summary>
  /// 
  /// </summary>
  public class ObjectDumper
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
      var dumper = new ObjectDumper(depth) { _writer = log };
      dumper.WriteObject(null, element);
    }

    #endregion

    private TextWriter _writer;
    private int _pos;
    private int _level;
    private readonly int _depth;

    private ObjectDumper(int depth)
    {
      _depth = depth;
    }

    private void Write(string s)
    {
      if (s == null) return;
      _writer.Write(s);
      _pos += s.Length;
    }

    private void WriteIndent()
    {
      for (var i = 0; i < _level; i++) _writer.Write("  ");
    }

    private void WriteLine()
    {
      _writer.WriteLine();
      _pos = 0;
    }

    private void WriteTab()
    {
      Write("  ");
      while (_pos % 8 != 0) Write(" ");
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
        var members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);

        if (element is IEnumerable enumerableElement)
        {
          WriteEnumerable(enumerableElement, prefix);
        }
        else
        {
          WriteMemberInfo(element, prefix, members);
          DepthWriter(element, members);
        }
      }
    }

    private void WriteMemberInfo(object element, string prefix, IEnumerable<MemberInfo> members)
    {
      WriteIndent();
      Write(prefix);
      var propWritten = false;
      foreach (var m in members)
      {
        var f = m as FieldInfo;
        var p = m as PropertyInfo;
        if (f == null && p == null) continue;

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

        WriteMemberInfoDetails(element, f, p);
      }
      if (propWritten) WriteLine();
    }

    private void WriteMemberInfoDetails(object element, FieldInfo f, PropertyInfo p)
    {
      var t = f != null ? f.FieldType : p.PropertyType;
      if (t.IsValueType || t == typeof(string))
      {
        WriteValue(f != null ? f.GetValue(element) : p.GetValue(element, null));
      }
      else
      {
        Write(typeof(IEnumerable).IsAssignableFrom(t) ? "..." : "{ }");
      }
    }

    private void DepthWriter(object element, IEnumerable<MemberInfo> members)
    {
      if (_level >= _depth) return;

      foreach (var m in members)
      {
        var f = m as FieldInfo;
        var p = m as PropertyInfo;

        if (f == null && p == null) continue;
        var t = f != null ? f.FieldType : p.PropertyType;

        if (t.IsValueType || t == typeof(string)) continue;
        var value = f != null ? f.GetValue(element) : p.GetValue(element, null);

        if (value == null) continue;
        _level++;
        WriteObject(m.Name + ": ", value);
        _level--;
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
      foreach (var item in enumerableElement)
      {
        if (item is IEnumerable && !(item is string))
        {
          WriteIndent();
          Write(prefix);
          Write("...");
          WriteLine();
          if (_level >= _depth) continue;
          _level++;
          WriteObject(prefix, item);
          _level--;
        }
        else
        {
          WriteObject(prefix, item);
        }
      }
    }

    private void WriteValue(object o)
    {
      switch (o)
      {
        case null:
          Write("null");
          break;
        case DateTime time:
          Write(time.ToShortDateString());
          break;
        case ValueType _:
        case string _:
          Write(o.ToString());
          break;
        case IEnumerable _:
          Write("...");
          break;
        default:
          Write("{ }");
          break;
      }
    }
  }
}
