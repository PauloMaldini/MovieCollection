using AutoMapper;
using MovieCollection.Core.Entities;
using MovieCollection.Web.Models.Movie;

namespace MovieCollection.Web.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModel>()
                .ForMember(x => x.Producer,
                    y => y.MapFrom(
                        z => $"{z.Producer.FirstName} {z.Producer.LastName}"));
        }
    }
}