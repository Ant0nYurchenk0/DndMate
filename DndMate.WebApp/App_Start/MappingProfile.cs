using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;

namespace DndMate.WebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ItemDto, Item>();
            Mapper.CreateMap<Item, ItemDto>();

            Mapper.CreateMap<NoteDto, Note>();
            Mapper.CreateMap<Note, NoteDto>();

            Mapper.CreateMap<SpellDto, Spell>();
            Mapper.CreateMap<Spell, SpellDto>();

            Mapper.CreateMap<GamespaceDto, Gamespace>();
            Mapper.CreateMap<Gamespace, GamespaceDto>();

            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<NotificationDto, Notification>();

            Mapper.CreateMap<GamespaceChar, GamespaceCharDto>();
            Mapper.CreateMap<GamespaceCharDto, GamespaceChar>();

            Mapper.CreateMap<Note, Note>();
            Mapper.CreateMap<Item, Item>();
            Mapper.CreateMap<Spell, Spell>();
            Mapper.CreateMap<Gamespace, Gamespace>();
            Mapper.CreateMap<GamespaceChar, GamespaceChar>();
        }
    }
}