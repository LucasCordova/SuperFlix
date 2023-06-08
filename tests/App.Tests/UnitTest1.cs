using App.Services;

namespace App.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestGetPopularMoviesShouldReturnMovieRecords()
    {
        var response = await MovieClient.GetPopularMovies();

        Assert.That(response, Is.Not.Null);
        Assert.That(response!.results.Count, Is.Not.EqualTo(0));
    }
}