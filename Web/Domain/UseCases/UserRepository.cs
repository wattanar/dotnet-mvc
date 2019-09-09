using Web.Data;
using Web.Domain.Entities;
using Web.Domain.Repositories;

namespace Web.Domain.UseCases
{
  public class UserRepository : BaseRepository<Users>, IUserRepository
  {
    public UserRepository(DataDbContext dataDbContext) : base(dataDbContext)
    {
    }

    public Users GetSomeUser(int id)
    {
      return FirstOrDefault(o => o.Id == id);
    }
  }
}