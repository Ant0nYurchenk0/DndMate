using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Repositories
{
    public class GamespaceRepository
    {
        private ApplicationDbContext _context;
        private CharactersRepository _charRepository;


        public GamespaceRepository(ApplicationDbContext context, CharactersRepository charRepository)
        {
            _context = context;
            _charRepository = charRepository;
        }
        public void Create(GamespaceDto gamespaceDto, string userId)
        {
            var gamespace = Mapper.Map<GamespaceDto, Gamespace>(gamespaceDto);
            _context.Gamespaces.Add(gamespace);
            _context.SaveChanges();

            var gamespaceChar = new GamespaceChar();
            gamespaceChar.CharacterId = userId;
            gamespaceChar.GamespaceId = gamespace.Id;
            gamespaceChar.Role = Role.Master;
            gamespaceChar.Level = 20;
            gamespaceChar.Name = "Master";
            _context.Characters.Add(gamespaceChar);
            _context.SaveChanges();
        }

        public void Update(GamespaceDto gamespaceDto)
        {
            var gamespaceInDb = _context.Gamespaces.SingleOrDefault(x => x.Id == gamespaceDto.Id);
            Mapper.Map(gamespaceDto, gamespaceInDb);
            _context.SaveChanges();
        }
        public void Leave(GamespaceChar gamespaceCharacter)
        {
            if(gamespaceCharacter.Role == Role.Master)
            {
                var gamespace = _context.Gamespaces.Single(g => g.Id == gamespaceCharacter.GamespaceId);
                _context.Gamespaces.Remove(gamespace);
            }
            else
            {
                var gamespaceChar = _context.Characters.SingleOrDefault(gs => gs.GamespaceId == gamespaceCharacter.GamespaceId
                                    && gs.CharacterId == gamespaceCharacter.CharacterId);
                _context.Characters.Remove(gamespaceChar);
            }
            _context.SaveChanges();                
        }
        public GamespacePropsViewModel GetViewModel(int id, string userId)
        {
            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            var viewModel = new GamespacePropsViewModel();
            viewModel.Gamespace = Mapper.Map<Gamespace, GamespaceDto>(gamespace);
            viewModel.Character = Mapper.Map<GamespaceCharDto>(_charRepository.GetCharacter(userId, id));
            viewModel.Characters = _context.Characters.Where(c => c.GamespaceId == id).ToList().Select(c=>Mapper.Map<GamespaceCharDto>(c));
            viewModel.Notification = new NotificationDto();
            viewModel.Notification.GamespaceId = id;
            return viewModel;
        }
        
    }
}