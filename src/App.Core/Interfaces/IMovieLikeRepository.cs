using App.Core.Entities;

namespace App.Core.Interfaces;

public interface IMovieLikeRepository
{
    Task<IEnumerable<MovieLike>> FindAll(); // Read
    Task<MovieLike?> GetByMovieLikeId(int id); // Read
    Task Update(MovieLike movieLike); // Update
    Task Add(MovieLike movieLike); // Create
    Task Delete(int movieLikeId);
}