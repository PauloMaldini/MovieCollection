using AutoMapper;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Entities;
using MovieCollection.Web.Models.Movie;

namespace MovieCollection.Web.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModel>()
                .ForMember(x => x.MovieId,
                    y => y.MapFrom(
                        z => z.Id))
                .ForMember(x => x.Producer,
                    y => y.MapFrom(
                        z => $"{z.Producer.FirstName} {z.Producer.LastName}"))
                .Include<Movie, DetailMovieViewModel>();

            CreateMap<Selection<Movie>, ListMovieViewModel>()
                .ForMember(x => x.Movies, 
                    y => y.MapFrom(
                        z => z.Items));

            CreateMap<Movie, DetailMovieViewModel>();


        }
    }
}