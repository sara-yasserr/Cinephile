using AutoMapper;
using LetterboxdProject.DTOs.FilmDTOs;
using LetterboxdProject.Models;
namespace LetterboxdProject.MapperConfig
{
    public class mappConfig: Profile
    {
        public mappConfig() 
        {
            CreateMap<Film,FilmDTO >().ReverseMap();

            //CreateMap<, >().ReverseMap();
        }
    }
}
