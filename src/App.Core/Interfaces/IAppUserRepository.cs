using App.Core.Entities.AppUserAggregate;

namespace App.Core.Interfaces;

public interface IAppUserRepository
{
    Task<IEnumerable<AppUser>> FindAll(); // Read
    Task<AppUser?> GetByAppUserId(int id); // Read
    Task<AppUser?> GetByIdentityUserId(string id); // Read
    Task Update(AppUser appUser); // Update
    Task Add(AppUser appUser); // Create
    Task Delete(int appUserId);
}