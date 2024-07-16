using AutoMapper;
using MovieDatabase.Dto;
using MovieDatabase.Models;

namespace MovieDatabase.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>()
                 .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorMovies.Select(ma => ma.Actor.FirstName + " " + ma.Actor.LastName).ToList()))
                .ForMember(dest => dest.Theaters, opt => opt.MapFrom(src => src.TheaterMovies.Select(mt => mt.Theater.Name).ToList()));
            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Director, opt => opt.Ignore()) // Assuming Director is a complex type in Movie
                .ForMember(dest => dest.ActorMovies, opt => opt.Ignore()); // Assuming ActorMovies is a collection in Movie


            CreateMap<Theater, TheaterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));
            CreateMap<TheaterDto, Theater>();

            CreateMap<Worker, WorkerDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies))
                .ForMember(dest => dest.ActorMovies, opt => opt.MapFrom(src => src.ActorMovies));
            CreateMap<WorkerDto, Worker>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Role), src.Role)));

            CreateMap<Worker, MovieDto>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.DirectorId, opt => opt.MapFrom(src => src.Id));
            CreateMap<MovieDto, Worker>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => splitDirector(src.Director, 0)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => splitDirector(src.Director, 1)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DirectorId));
        }

        private string splitDirector(string fullName, int i)
        {
            return fullName.Split(" ")[i];
        }
    }
}
