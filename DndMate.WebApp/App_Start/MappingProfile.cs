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

            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<NotificationDto, Notification>();

            Mapper.CreateMap<SpellDto, Spell>();
            Mapper.CreateMap<Spell, SpellDto>();

            Mapper.CreateMap<GamespaceChar, GamespaceCharDto>();
            Mapper.CreateMap<GamespaceCharDto, GamespaceChar>();

            Mapper.CreateMap<GamespaceChar, GamespaceChar>();
            Mapper.CreateMap<Gamespace, Gamespace>();
            Mapper.CreateMap<Spell, Spell>();
        }
    }
}