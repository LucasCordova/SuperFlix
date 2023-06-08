using App.Core.Entities;

namespace App.Core.Interfaces;

public interface IMovieLikeRepository
{
    IEnumerable<MovieLike> FindAll(); // Read
    MovieLike GetByMovieLikeId(int id); // Read
    void Update(MovieLike movieLike); // Update
    void Add(MovieLike movieLike); // Create
    void Delete(int movieLikeId);
}

