using AutoMapper;
using MovieMateAPI.Models;

namespace MovieMateAPI.DTOs
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<createUserGenredDTO, UserGenre>();
        }
    }
}
