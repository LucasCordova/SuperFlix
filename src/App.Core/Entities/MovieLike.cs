using App.Core.Interfaces;

namespace App.Core.Entities;

public class MovieLike : EntityBase, IAggregateRoot
{
    public int MovieId {get; set;}
    public int AppUserId {get; set;}
}