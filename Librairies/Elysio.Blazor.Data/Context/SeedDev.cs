using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elysio.Blazor.Data.Context
{
    public class SeedDev : Seed
    {
        private readonly IServiceProvider _services;

        public SeedDev(MyDbContext Context, IServiceProvider services)
            : base(Context, services)
        {
            _services = services;
        }

        public override async Task Run()
        {
            await base.Run();
        }
    }
}
