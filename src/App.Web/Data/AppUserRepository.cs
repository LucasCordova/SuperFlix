using App.Core.Entities.AppUserAggregate;
using App.Core.Interfaces;

namespace App.Web.Data;

public class AppUserRepository : IAppUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AppUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<AppUser> FindAll()
    {
        throw new NotImplementedException();
    }

    public AppUser? GetByAppUserId(int id)
    {
        throw new NotImplementedException();
    }

    public AppUser? GetByIdentityUserId(string id)
    {
        return _dbContext.AppUsers.FirstOrDefault(x => x.IdentityDbId == id);
    }

    public void Update(AppUser appUser)
    {
        throw new NotImplementedException();
    }

    public void Add(AppUser appUser)
    {
        throw new NotImplementedException();
    }

    public void Delete(int appUserId)
    {
        throw new NotImplementedException();
    }
}