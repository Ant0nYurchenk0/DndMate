﻿using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;

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

            Mapper.CreateMap<NoteDto, Note>();
            Mapper.CreateMap<Note, NoteDto>();

            Mapper.CreateMap<Note, Note>();
            Mapper.CreateMap<GamespaceChar, GamespaceChar>();
            Mapper.CreateMap<Gamespace, Gamespace>();
            Mapper.CreateMap<Spell, Spell>();
        }
    }
}