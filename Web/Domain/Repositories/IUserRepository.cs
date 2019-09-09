using Web.Domain.Entities;

namespace Web.Domain.Repositories
{
  public interface IUserRepository : IBaseRepository<Users>
  {
    Users GetSomeUser(int id);
  }
}