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
    public class GamespaceRepository
    {
        private ApplicationDbContext _context;

        public GamespaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        internal void Create(GamespaceDto gamespaceDto, string userId)
        {
            var gamespace = Mapper.Map<GamespaceDto, Gamespace>(gamespaceDto);
            _context.Gamespaces.Add(gamespace);
            _context.SaveChanges();

            var gamespaceChar = new GamespaceChar();
            gamespaceChar.CharacterId = userId;
            gamespaceChar.GamespaceId = gamespace.Id;
            gamespaceChar.Role = Role.Master;
            _context.GamespaceCharacters.Add(gamespaceChar);
            _context.SaveChanges();
        }

        internal void Update(GamespaceDto gamespaceDto)
        {
            var gamespaceInDb = _context.Gamespaces.SingleOrDefault(x => x.Id == gamespaceDto.Id);
            Mapper.Map(gamespaceDto, gamespaceInDb);
            _context.SaveChanges();
        }
        internal void Leave(GamespaceChar gamespaceCharacter)
        {
            if(gamespaceCharacter.Role == Role.Master)
            {
                var gamespace = _context.Gamespaces.Single(g => g.Id == gamespaceCharacter.GamespaceId);
                _context.Gamespaces.Remove(gamespace);
            }
            else
            {
                _context.GamespaceCharacters.Remove(gamespaceCharacter);
            }
            _context.SaveChanges();                
        }
        //internal void AddUser(string userId, int gamespaceId)
        //{
        //    if (_context.GamespaceCharacters.Any(gs => gs.GamespaceId == gamespaceId && gs.CharacterId == userId))
        //        return;
        //    var gamespaceChar = new GamespaceChar();
        //    gamespaceChar.CharacterId = userId;
        //    gamespaceChar.GamespaceId = gamespaceId;
        //    gamespaceChar.Role = Role.Player;
        //    _context.GamespaceCharacters.Add(gamespaceChar);
        //    _context.SaveChanges();
        //}
    }
}