using ByteDecoder.Queryology.Example.Models;

namespace ByteDecoder.Queryology.Example.Queries;

public class ExplicitLoadingQueryExampleOne : QueryBase<EfCoreContext>
{
    public override void Execute()
    {
        var book = DataContext.Books.First();

        // Load all Author Book references
        DataContext.Entry(book).Collection(b => b.AuthorsLink).Load();

        // Load all authors in the AuthorBook collection
        foreach (var authorLink in book.AuthorsLink)
        {
            DataContext.Entry(authorLink).Reference(r => r.Author).Load();
        }

        // Load all reviews
        DataContext.Entry(book).Collection(c => c.Reviews).Load();

        // Load all PriceOffer
        DataContext.Entry(book).Reference(r => r.Promotion).Load();

        Data = book;
        DisplayData("Eager Loading EF Core Query - ExplicitLoadingQueryExampleOne", 3);
    }
}
