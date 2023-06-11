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

    public Task Add(MovieLike movieLike)
    {
        _dbContext.MovieLikes.Add(movieLike);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task Delete(int movieLikeId)
    {
        var movieLike = await GetByMovieLikeId(movieLikeId);
        if (movieLike != null)
        {
            _dbContext.MovieLikes.Remove(movieLike);
            await _dbContext.SaveChangesAsync();
        }

        await Task.CompletedTask;
    }

    public Task<MovieLike?> GetByMovieLikeId(int id)
    {
        return Task.FromResult(_dbContext.MovieLikes.FirstOrDefault(x => x.Id == id));
    }

    public Task Update(MovieLike movieLike)
    {
        _dbContext.Update(movieLike);
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public Task<IEnumerable<MovieLike>> FindAll()
    {
        return Task.FromResult<IEnumerable<MovieLike>>(_dbContext.MovieLikes.ToList());
    }
}