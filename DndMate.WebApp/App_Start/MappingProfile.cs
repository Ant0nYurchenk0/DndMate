using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<GamespaceDto, Gamespace>();
            Mapper.CreateMap<Gamespace, GamespaceDto>();

            Mapper.CreateMap<Gamespace, Gamespace>();
        }
    }
}