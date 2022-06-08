using AutoMapper;
using DndMate.WebApp.Dtos;
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
    public class SpellsController : Controller
    {
        private CharactersRepository _characterRepository;
        private ApplicationDbContext _context;

        // GET: Spells
        public SpellsController(ApplicationDbContext context, CharactersRepository repository)
        {
            _characterRepository = repository;
            _context = context;
        }
        [Route("Spells")]
        public ActionResult Index(int gamespaceId)
        {
            var spells = _context.Spells.Where(s => s.GamespaceId == gamespaceId).ToList().Select(s => Mapper.Map<SpellDto>(s));
            return View(spells);
        }
        [Route("Spells/Create")]
        public ActionResult Create(int gamespaceId)
        {
            var spellDto = new SpellDto();
            spellDto.GamespaceId = gamespaceId;
            return View("Form", spellDto);
        }
        [Route("Spells/Delete")]
        public ActionResult Delete(int id)
        {
            var spell = _context.Spells.SingleOrDefault(s => s.Id == id);
            if (spell == null)
                return HttpNotFound();
            _context.Spells.Remove(spell);
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
            return View("Form", spellDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SpellDto spellDto)
        {
            if (!ModelState.IsValid)
                return View("Form", spellDto);

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
        [Route("Spells/Get")]
        public ActionResult Get(int id)
        {
            var viewModel = new GetSpellViewModel();
            var spell = _context.Spells.SingleOrDefault(s => s.Id == id);
            if (spell == null)
                return HttpNotFound();
            viewModel.Spell = Mapper.Map<Spell, SpellDto>(spell);
            viewModel.Characters = _characterRepository.GetCharacters(spell.GamespaceId);
            return View("Get", viewModel);
        }
    }
}