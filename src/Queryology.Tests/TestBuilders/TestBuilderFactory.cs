﻿using System.Collections.Generic;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Tests.Queries;
using ByteDecoder.Queryology.Tests.Support;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders;

internal class TestBuilderFactory
{
    public QueryologyEngineTestBuilder<T> Create<T>()
      where T : DbContext, new()
    {
        return new QueryologyEngineTestBuilder<T>();
    }

    public IEnumerable<IQuery<NullDbContext>> CreateNullDbContextObjectQueries(NullDbContext dbContext) =>
        new List<IQuery<NullDbContext>>()
            {
                new QueryTypeNullDbContextOne(dbContext, TestObjectViewer.DisplayData),
                new QueryTypeNullDbContextTwo(dbContext, TestObjectViewer.DisplayData),
                new QueryTypeNullDbContextThree(dbContext, TestObjectViewer.DisplayData)
            };
}
