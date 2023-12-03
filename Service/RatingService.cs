using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {


        public IRatingRepositorycs _ratingRepository;
        public RatingService(IRatingRepositorycs ratingRepository)
        {
            _ratingRepository = ratingRepository;

        }

        public async Task<Rating> addRating(Rating rating)
        {

            return await _ratingRepository.addRating(rating);
        }







    }
}
