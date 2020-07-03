using System;
using Queryology.Example.Models;

namespace ByteDecoder.Queryology.Example.Queries
{
  public class NeverAgainQuery : QueryBase<EfCoreContext>
  {
    public override bool Executable => false;

    public NeverAgainQuery(EfCoreContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
      Console.WriteLine("Never again.. I will never get executwed by QueryologyEngine =(");
    }
  }
}
