using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
using DndMate.WebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private ApplicationDbContext _context;
        private GamespaceRepository _gamespaceRepository;

        // GET: Notes
        public NotesController(ApplicationDbContext context, GamespaceRepository gamespaceRepository)
        {
            _context = context;
            _gamespaceRepository = gamespaceRepository;
        }
        public ActionResult Index(int id)
        {
            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            if (gamespace == null)
                return HttpNotFound();
            var userId = User.Identity.GetUserId();
            var character = _context.Characters.SingleOrDefault(c => c.CharacterId == userId && c.GamespaceId == id);
            var master = _context.Characters.SingleOrDefault(c => c.GamespaceId == id && c.CharacterClass == CharacterClass.Master);
            if (character == null)
                return HttpNotFound();
            var viewModel = new NoteListViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(id, userId);
            viewModel.MasterNotes = _context.Notes.Where(n => n.CharacterId == master.Id).ToList().Select(n=>Mapper.Map<NoteDto>(n));
            viewModel.MyNotes = _context.Notes.Where(n => n.CharacterId == character.Id).ToList().Select(n => Mapper.Map<NoteDto>(n));
            return View(viewModel);
        }
        [Route("Notes/Create")]
        public ActionResult Create(int charId, int gamespaceId)
        {
            var viewModel = new NoteFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
            viewModel.Note = new NoteDto();
            viewModel.Note.CharacterId = charId;
            return View("Form", viewModel);
        }
        [Route("Notes/Delete")]
        public ActionResult Delete(int id)
        {
            var note = _context.Notes.Include(n => n.Character).SingleOrDefault(s => s.Id == id);
            var gamespaceId = note.Character.GamespaceId;
            if (note == null)
                return HttpNotFound();
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index", "Notes", new { id = gamespaceId});
        }
        [Route("Notes/Edit")]
        public ActionResult Edit(int id)
        {
            var note = _context.Notes.Include(n => n.Character).SingleOrDefault(s => s.Id == id);
            if (note == null)
                return HttpNotFound();
            var noteDto = Mapper.Map<Note, NoteDto>(note);
            var viewModel = new NoteFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(note.Character.GamespaceId, User.Identity.GetUserId());
            viewModel.Note = noteDto;
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NoteFormViewModel form, int gamespaceId)
        {
            var noteDto = form.Note;
            if (!ModelState.IsValid)
            {
                var viewModel = new NoteFormViewModel();
                viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
                viewModel.Note = noteDto;
                return View("Form", viewModel);
            }

            if (!_context.Notes.Any(s => s.Id == noteDto.Id))
            {
                _context.Notes.Add(Mapper.Map<Note>(noteDto));
            }
            else
            {
                var noteInDb = _context.Notes.SingleOrDefault(s => s.Id == noteDto.Id);
                Mapper.Map(noteDto, noteInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Notes", new { id = gamespaceId });
        }
    }
}