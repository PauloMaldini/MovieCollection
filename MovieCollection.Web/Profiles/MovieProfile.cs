using AutoMapper;
using MovieCollection.Core.Concrete;
using MovieCollection.Core.Entities;
using MovieCollection.Web.Models.Movie;
using MovieCollection.Web.Models.Movie.Base;

namespace MovieCollection.Web.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModelBase>()
                .Include<Movie, MovieModel>()
                .Include<Movie, EditMovieViewModel>()
                .ForMember(x => x.MovieId,
                    y => y.MapFrom(
                        z => z.Id));

            CreateMap<Movie, MovieModel>()
                .ForMember(x => x.Producer,
                    y => y.MapFrom(
                        z => $"{z.Producer.FirstName} {z.Producer.LastName}"))
                .Include<Movie, DetailMovieViewModel>();

            CreateMap<Selection<Movie>, ListMovieViewModel>()
                .ForMember(x => x.Movies, 
                    y => y.MapFrom(
                        z => z.Items));

            CreateMap<Movie, DetailMovieViewModel>();
            
            CreateMap<Movie, EditMovieViewModel>()
                .ForMember(x => x.ProducerId, 
                    y => y.MapFrom(
                        z => z.ProducerRefId));

            CreateMap<EditMovieViewModel, Movie>()
                .ForMember(x => x.PosterFileName, 
                    y => y.Ignore())
                .ForMember(x => x.ProducerRefId, 
                    y => y.MapFrom(
                        z => z.ProducerId));
        }
    }
}