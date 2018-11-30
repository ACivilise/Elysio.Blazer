using Elysio.Blazor.Data.Context;
using Elysio.Blazor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elysio.Blazor.Data.Repositories.Articles
{
    public class ArticlesRepository : Repository<MyDbContext, Article>, IArticlesRepository
    {
        #region Ctor.Dtor
        public ArticlesRepository(MyDbContext context)
            : base(context)
        { }
        #endregion

        #region Methods

        #endregion
    }
}
