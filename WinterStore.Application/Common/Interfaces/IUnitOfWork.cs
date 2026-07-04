using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SevaChangesAsync(CancellationToken cancellationToken = default);
    }
}
