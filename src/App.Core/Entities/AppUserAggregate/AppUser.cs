using App.Core.Interfaces;

namespace App.Core.Entities.AppUserAggregate;

public class AppUser : EntityBase, IAggregateRoot
{
    public string? IdentityDbId { get; set; }

    // Add properties here that are specific for an App User entity, e.g. FirstName, LastName, etc.
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public DateTime? DateOfBirth {get; set;}
}