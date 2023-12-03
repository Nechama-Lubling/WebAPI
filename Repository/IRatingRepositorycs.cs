using Entities;

namespace Repository
{
    public interface IRatingRepositorycs
    {
        Task<Rating> addRating(Rating rating);
    }
}