using System;
using System.Threading.Tasks;
using WebSite.DataLayer.Context;

namespace WebSite.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        MyContext Context { get; }
        Task CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public MyContext Context { get; }

        public UnitOfWork(MyContext context)
        {
            Context = context;
        }
        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }


}
