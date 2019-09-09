using System;
using Web.Domain.Repositories;

namespace Web.Domain
{
  public interface IUnitOfWork : IDisposable
  {
    IUserRepository Users { get; }
    int Complete();
  }
}