using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BingoSentence, BingoSentenceDto>();
            CreateMap<BingoSentenceDto, BingoSentence>();
        }
    }
}