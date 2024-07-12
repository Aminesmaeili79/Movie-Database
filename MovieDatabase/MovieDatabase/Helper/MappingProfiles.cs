using AutoMapper;
using MovieDatabase.Dto;
using MovieDatabase.Models;

namespace MovieDatabase.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Theater, TheaterDto>();
            CreateMap<TheaterDto, Theater>();
            CreateMap<Worker, WorkerDto>();
            CreateMap<WorkerDto, Worker>();
        }
    }
}
