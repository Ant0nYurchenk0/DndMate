using AutoMapper;
using DndMate.WebApp.Dtos;
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
    }
}