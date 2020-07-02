using System;
using ByteDecoder.Queryology;
using Queryology.Example.Models;

namespace Queryology.Example
{
  class Program
  {
    static void Main(string[] args)
    {
      new QueryologyEngine<EfCoreContext>(new EfCoreContext()).Execute();
      Console.ReadLine();
    }
  }
}
