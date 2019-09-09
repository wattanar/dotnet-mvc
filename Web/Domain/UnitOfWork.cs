using Web.Data;
using Web.Domain.Repositories;
using Web.Domain.UseCases;

namespace Web.Domain
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataDbContext _dataDbContext;

    public UnitOfWork(DataDbContext dataDbContext)
    {
      _dataDbContext = dataDbContext;
      Users = new UserRepository(_dataDbContext);
    }

    public IUserRepository Users { get; private set; }

    public int Complete()
    {
      return _dataDbContext.SaveChanges();
    }

    public void Dispose()
    {
      _dataDbContext.Dispose();
    }
  }
}