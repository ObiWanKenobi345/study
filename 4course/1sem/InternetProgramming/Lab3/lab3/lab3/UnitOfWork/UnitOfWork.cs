using Contracts.Core;
using Contracts.UnitOfWork;
using lab3.Context;

namespace lab3.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IStudentDb _studentDb;

        public UnitOfWork(IStudentDb studentDb)
        {
            _studentDb = studentDb;
        }

        public void Commit()
        {
            _studentDb.Commit();
        }

        public void Dispose()
        {
            Commit();
        }
    }
}