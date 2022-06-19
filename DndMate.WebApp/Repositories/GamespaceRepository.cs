using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.ViewModels;
using System.Linq;

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
        public int Create(GamespaceDto gamespaceDto, string userId, string masterName)
        {
            var gamespace = Mapper.Map<GamespaceDto, Gamespace>(gamespaceDto);
            _context.Gamespaces.Add(gamespace);
            _context.SaveChanges();

            var gamespaceChar = new GamespaceChar();
            gamespaceChar.CharacterId = userId;
            gamespaceChar.GamespaceId = gamespace.Id;
            gamespaceChar.CharacterClass = CharacterClass.Master;
            gamespaceChar.Level = 20;
            gamespaceChar.Name = masterName;
            _context.Characters.Add(gamespaceChar);
            _context.SaveChanges();
            return gamespace.Id;
        }

        public void Update(GamespaceDto gamespaceDto, string masterName)
        {
            var gamespaceInDb = _context.Gamespaces.SingleOrDefault(x => x.Id == gamespaceDto.Id);
            Mapper.Map(gamespaceDto, gamespaceInDb);
            var master = _context.Characters.Single(c => c.CharacterClass == CharacterClass.Master && c.GamespaceId == gamespaceDto.Id);
            master.Name = masterName;
            _context.SaveChanges();
        }
        public void Leave(GamespaceChar gamespaceCharacter)
        {
            if (gamespaceCharacter.CharacterClass == CharacterClass.Master)
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
            viewModel.Characters = _context.Characters.Where(c => c.GamespaceId == id).ToList().Select(c => Mapper.Map<GamespaceCharDto>(c));
            viewModel.Notification = new NotificationDto();
            viewModel.Notification.GamespaceId = id;
            return viewModel;
        }

    }
}