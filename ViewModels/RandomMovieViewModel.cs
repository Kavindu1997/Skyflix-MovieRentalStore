using SkyFlix.Models;

namespace SkyFlix.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie? Movie { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}