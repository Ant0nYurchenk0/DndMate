using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
using DndMate.WebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    [Authorize]
    public class SpellsController : Controller
    {
        private CharactersRepository _characterRepository;
        private ApplicationDbContext _context;
        private GamespaceRepository _gamespaceRepository;


        // GET: Spells
        public SpellsController(ApplicationDbContext context, CharactersRepository repository, GamespaceRepository gamespaceRepository)
        {
            _characterRepository = repository;
            _context = context;
            _gamespaceRepository = gamespaceRepository;
        }
        [Route("Spells")]
        public ActionResult Index(int gamespaceId)
        {
            var userId = User.Identity.GetUserId();
            var character = _context.Characters.Single(c => c.GamespaceId == gamespaceId && c.CharacterId == userId);
            var viewModel = new SpellListViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
            viewModel.Spells = _context.Spells.Where(s => s.GamespaceId == gamespaceId).ToList().Select(s => Mapper.Map<SpellDto>(s)) ?? new List<SpellDto>();
            viewModel.AssignedSpells = _context.CharacterSpells.Where(s => s.CharacterId == character.Id).ToList().Select(s => Mapper.Map<SpellDto>(s.Spell)) ?? new List<SpellDto>();
            viewModel.AssignedSpells = _context.CharacterSpells.Where(s => s.CharacterId == character.Id).ToList().Select(s => Mapper.Map<SpellDto>(s.Spell)) ?? new List<SpellDto>();
            return View(viewModel);
        }
        [Route("Spells/Create")]
        public ActionResult Create(int gamespaceId)
        {
            var viewModel = new SpellFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
            viewModel.Spell = new SpellDto();
            viewModel.Spell.GamespaceId = gamespaceId;
            return View("Form", viewModel);
        }
        [Route("Spells/Delete")]
        public ActionResult Delete(int id)
        {
            var spell = _context.Spells.SingleOrDefault(s => s.Id == id);
            if (spell == null)
                return HttpNotFound();
            _context.Spells.Remove(spell);
            foreach(var charSpell in _context.CharacterSpells.Where(cs=>cs.SpellId == id))
                _context.CharacterSpells.Remove(charSpell);
            _context.SaveChanges();
            return RedirectToAction("Index", "Spells", new {gamespaceId = spell.GamespaceId});
        }
        [Route("Spells/Edit")]
        public ActionResult Edit(int id)
        {
            var spell = _context.Spells.SingleOrDefault(s => s.Id == id);
            if (spell == null)
                return HttpNotFound();
            var spellDto = Mapper.Map<Spell, SpellDto>(spell);
            var viewModel = new SpellFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(spellDto.GamespaceId, User.Identity.GetUserId());
            viewModel.Spell = spellDto;
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SpellFormViewModel form)
        {
            var spellDto = form.Spell;
            if (!ModelState.IsValid)
            {
                var viewModel = new SpellFormViewModel();
                viewModel.Gamespace = _gamespaceRepository.GetViewModel(spellDto.GamespaceId, User.Identity.GetUserId());
                viewModel.Spell = spellDto;
                return View("Form", viewModel);
            }

            if (!_context.Spells.Any(s => s.Id == spellDto.Id))
            {
                _context.Spells.Add(Mapper.Map<Spell>(spellDto));
            }
            else
            {
                var spellInDb = _context.Spells.SingleOrDefault(s => s.Id == spellDto.Id);
                Mapper.Map(spellDto, spellInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Spells", new { gamespaceId = spellDto.GamespaceId });
        }
    }
}