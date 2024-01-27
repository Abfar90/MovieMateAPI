using AutoMapper;
using MovieMateAPI.Models;

namespace MovieMateAPI.DTOs
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserGenres, opt => opt.MapFrom(src => src.UserGenres.Select(ug => ug.Genre)));
            CreateMap<Genre, GenreDTO>();
            CreateMap<UserGenre, UserGenreDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Title));
            CreateMap<UserGenre, ResponseUserGenreDTO>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genre.UserGenres.Select(ug => ug.Genre)));
            CreateMap<createUserGenredDTO, UserGenre>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.MovieDetails.Title))
                .ForMember(dest => dest.Release, opt => opt.MapFrom(src => src.MovieDetails.Release));
            CreateMap<Movie, UpdateResponseDTO>();
            CreateMap<MovieDetail, MovieDetailDTO>();
        }
    }
}

