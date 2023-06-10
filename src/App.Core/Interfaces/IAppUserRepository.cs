using App.Core.Entities.AppUserAggregate;

namespace App.Core.Interfaces;

public interface IAppUserRepository
{
    IEnumerable<AppUser> FindAll(); // Read
    AppUser? GetByAppUserId(int id); // Read
    AppUser? GetByIdentityUserId(string id); // Read
    void Update(AppUser appUser); // Update
    void Add(AppUser appUser); // Create
    void Delete(int appUserId);
}