
using Elysio.Blazor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elysio.Blazor.Data.Context
{
    interface IMyDbContext
    {
        DbSet<Article> Articles { get; }

    }
}
