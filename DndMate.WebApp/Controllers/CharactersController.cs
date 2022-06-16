using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
using DndMate.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    public class CharactersController : Controller
    {
        private ApplicationDbContext _context;
        private CharactersRepository _repository;
        private GamespaceRepository _gamespaceRepository;


        // GET: Characters
        public CharactersController(ApplicationDbContext context, CharactersRepository repository, GamespaceRepository gamespaceRepository)
        {
            _context = context;
            _repository = repository;
            _gamespaceRepository = gamespaceRepository;
        }
        public ActionResult Index(int gamespaceId)
        {
            return View(_repository.GetCharacters(gamespaceId));
        }
        public ActionResult AssignSpell(int charId, int spellId)
        {
            var gamespaceId = _context.Characters.Single(c=>c.Id == charId).GamespaceId;
            if(!_context.CharacterSpells.Any(cs=>cs.CharacterId == charId && cs.SpellId == spellId))
            {
                var characterSpell = new GamespaceCharacterSpell();
                characterSpell.CharacterId = charId;
                characterSpell.SpellId = spellId;
                characterSpell.IsActive = false;
                _context.CharacterSpells.Add(characterSpell);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Spells", new { gamespaceId = gamespaceId });            
        }
        public ActionResult DropSpell(int charId = 0, int spellId)
        {
            var gamespaceId = _context.Characters.Single(c => c.Id == charId).GamespaceId;
            var characterSpell = _context.CharacterSpells.SingleOrDefault(cs => cs.CharacterId == charId && cs.SpellId == spellId);
            if (characterSpell == null)
                return HttpNotFound();
            _context.CharacterSpells.Remove(characterSpell);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Spells", new { gamespaceId = gamespaceId });
        }
        [Route("Characters/Create")]
        public ActionResult Create(string charId, int gamespaceId)
        {
            var charDto = new GamespaceCharDto();
            charDto.CharacterId = charId;
            charDto.GamespaceId = gamespaceId;
            charDto.Role = Role.Player;
            return View("Form", charDto);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(GamespaceCharDto characterDto)
        {
            if (!ModelState.IsValid)
                return View("Form", characterDto);

            if (!_context.Characters.Any(s => s.Id == characterDto.Id))
            {
                _context.Characters.Add(Mapper.Map<GamespaceChar>(characterDto));
            }
            else
            {
                var spellInDb = _context.Characters.SingleOrDefault(s => s.Id == characterDto.Id);
                Mapper.Map(characterDto, spellInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Get", "Gamespace", new { id = characterDto.GamespaceId});
        }
        [Route("Characters/Edit")]
        public ActionResult Edit(string charId, int gamespaceId)
        {
            var character = _context.Characters.SingleOrDefault(c => c.CharacterId == charId && c.GamespaceId == gamespaceId);
            if (character == null)
                return HttpNotFound();
            var characterDto = Mapper.Map<GamespaceCharDto>(character);
            return View("Form", characterDto);
        }
        public ActionResult Get(int id)
        {
            var viewModel = new CharacterViewModel();
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (character == null)
                return HttpNotFound();
            viewModel.Character = Mapper.Map<GamespaceCharDto>(character);
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(character.GamespaceId, character.CharacterId);
            return View(viewModel);
        }
    }
}