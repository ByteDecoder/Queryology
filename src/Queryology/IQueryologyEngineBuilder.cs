using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  public interface IQueryologyEngineBuilder<T> where T : DbContext
  {
    IQueryologyEngine<T> Build();
  }
}
