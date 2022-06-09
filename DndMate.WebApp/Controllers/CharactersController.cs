using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
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

        // GET: Characters
        public CharactersController(ApplicationDbContext context, CharactersRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public ActionResult Index(int gamespaceId)
        {
            return View(_repository.GetCharacters(gamespaceId));
        }
        public ActionResult AssignSpell(int charId, int spellId)
        {
            if(!_context.CharacterSpells.Any(cs=>cs.CharacterId == charId && cs.SpellId == spellId))
            {
                var characterSpell = new GamespaceCharacterSpell();
                characterSpell.CharacterId = charId;
                characterSpell.SpellId = spellId;
                characterSpell.IsActive = false;
                _context.CharacterSpells.Add(characterSpell);
                _context.SaveChanges();
            }
            return RedirectToAction("Get", "Spells", new { id = spellId });            
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
    }
}