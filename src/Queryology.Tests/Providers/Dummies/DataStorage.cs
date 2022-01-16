using System;
using System.Collections;
using System.Collections.Generic;

namespace ByteDecoder.Queryology.Tests.Providers.Dummies
{
    public class DataStorage
    {
        public IEnumerable<string> Friends => new[] { "Jeremias", "Matias" };
        public IEnumerable Materials => new[] { "Charcoral", "Indian Ink" };
        public IEnumerable Misc => new List<object> { "Pencil", 2.0f, 35.0M, DateTime.UtcNow };
        public IEnumerable Magical => null;
    }
}
