using System;
using System.Threading.Tasks;

namespace es.eit.Common.Model.Context
{
    public interface IContextBase : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
