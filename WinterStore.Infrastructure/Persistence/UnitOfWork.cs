using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;
using WinterStore.Infrastructure.Data;

namespace WinterStore.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WinterDbContext _db;

        public UnitOfWork(WinterDbContext db)
        {
            _db = db;
        }

        public async Task<int> SevaChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
