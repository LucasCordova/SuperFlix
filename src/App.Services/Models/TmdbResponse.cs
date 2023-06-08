namespace App.Services.Models;

public class TmdbResponse
{
    public int page { get; set; }
    public List<TmdbResult> results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}