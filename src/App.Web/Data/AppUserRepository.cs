using App.Core.Entities.AppUserAggregate;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Data;

public class AppUserRepository : IAppUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AppUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AppUser>> FindAll()
    {
        return await _dbContext.AppUsers.ToListAsync();
    }

    public async Task<AppUser?> GetByAppUserId(int id)
    {
        return await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AppUser?> GetByIdentityUserId(string id)
    {
        return await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.IdentityDbId == id);
    }

    public Task Update(AppUser appUser)
    {
        _dbContext.Update(appUser);
        return Task.FromResult(_dbContext.SaveChangesAsync());
    }

    public Task Add(AppUser appUser)
    {
        _dbContext.AppUsers.Add(appUser);

        return Task.FromResult(_dbContext.SaveChangesAsync());
    }

    public Task Delete(int appUserId)
    {
        _dbContext.AppUsers.Remove(new AppUser { Id = appUserId });

        return Task.FromResult(_dbContext.SaveChangesAsync());
    }
}