﻿using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Repositories
{
    public class CharactersRepository
    {
        private ApplicationDbContext _context;

        public CharactersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<GamespaceCharDto> GetCharacters(int id)
        {
            return _context.Characters.Where(c => c.GamespaceId == id).ToList().Select(c => Mapper.Map<GamespaceCharDto>(c));

        }
        public IEnumerable<GamespaceCharDto> GetPlayerCharacters(int id)
        {
            return _context.Characters.Where(c => c.GamespaceId == id && c.Role == Role.Player).ToList().Select(c => Mapper.Map<GamespaceCharDto>(c));
        }
    }
}