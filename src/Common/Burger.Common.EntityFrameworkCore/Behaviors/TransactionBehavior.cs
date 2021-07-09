using System.Threading;
using System.Threading.Tasks;
using Burger.Common.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Burger.Common.EntityFrameworkCore.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly DbContext _dbContext;

        public TransactionBehavior(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_dbContext.Database.CurrentTransaction == null && request is ICommand)
            {
                IDbContextTransaction? transaction = null;
                try
                {
                    transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

                    var response = await next();

                    await transaction.CommitAsync(cancellationToken);

                    return response;
                }
                finally
                {
                    // If not Committed, then it does automatic Rollback on Dispose
                    transaction?.Dispose();
                }
            }
            else
            {
                return await next();
            }
        }
    }
}
