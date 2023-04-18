using Ecommerce.Domain.Common;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Infrastructure.Persistence.context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private const int SQL_VIOLATION_UNIQUE_INDEX = 2601;
        private const int SQL_VIOLATION_UNIQUE_CONSTRAINT = 2627;
        private static ValidationResult UniqueErrorFormatter() => new("Cannot have a duplicate entities, please enter different values.");
        private bool isDisposed;

        private readonly ApplicationDbContext _dbContext;

        public delegate void ApplyRequested(UnitOfWork workUnit);

        public static event ApplyRequested? OnApplyRequested;

        public delegate void RollbackRequested(UnitOfWork workUnit);

        public static event RollbackRequested? OnRollbackRequested;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Apply()
        {
            OnApplyRequested?.Invoke(this);
        }

        public virtual void Rollback()
        {
            OnRollbackRequested?.Invoke(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveOrUpdate()
        {
            try
            {
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                var error = SaveChangesExceptionHandler(ex);
                if (error is not null)
                {
                    throw new UniqueConstraintException(error.ErrorMessage);
                }

                throw;
            }
        }

        private static ValidationResult? SaveChangesExceptionHandler(DbUpdateException dbUpdateException)
        {
            if (dbUpdateException?.InnerException is not SqlException sqlException)
            {
                return default;
            }

            if (sqlException.Number == SQL_VIOLATION_UNIQUE_INDEX ||
                sqlException.Number == SQL_VIOLATION_UNIQUE_CONSTRAINT)
            {
                return UniqueErrorFormatter();
            }

            return default;
        }

    }
}
