using Infrastructure.DB;

namespace Infrastructure.Service.Transaction
{
    public class TransactionHandler
    {
        private readonly AppDbContext _context;

        public TransactionHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {

                await operation();


                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {

                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}

