using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elysio.Blazor.Data.Context
{
    public class Seed
    {

        private readonly IServiceProvider _services;
        public MyDbContext Context { get; private set; }
        public Seed(MyDbContext context, IServiceProvider services)
        {
            Context = context;
            _services = services;
        }

        public virtual async Task Run()
        {
        }
    }
}
