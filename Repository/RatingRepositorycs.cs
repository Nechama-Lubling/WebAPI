using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepositorycs : IRatingRepositorycs
    {


        private readonly Manager214877003Context _managerContext;
        public RatingRepositorycs(Manager214877003Context managerContext)
        {
            _managerContext = managerContext;
        }

        public async Task<Rating> addRating(Rating rating)
        {
            await _managerContext.Ratings.AddAsync(rating);
            await _managerContext.SaveChangesAsync();
            return rating;

        }



    }
}
