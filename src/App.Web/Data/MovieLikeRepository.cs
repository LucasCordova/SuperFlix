using App.Core.Entities;
using App.Core.Interfaces;

namespace App.Web.Data;

public class MovieLikeRepository : IMovieLikeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MovieLikeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(MovieLike movieLike)
    {
        _dbContext.MovieLikes.Add(movieLike);
        _dbContext.SaveChanges();
    }

    public void Delete(int movieLikeId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MovieLike> FindAll()
    {
        return _dbContext.MovieLikes.ToList();
    }

    public MovieLike GetByMovieLikeId(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(MovieLike movieLike)
    {
        throw new NotImplementedException();
    }
}