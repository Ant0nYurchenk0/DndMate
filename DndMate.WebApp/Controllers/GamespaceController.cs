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
    public class GamespaceController : Controller
    {
        // GET: Gamespace
        private ApplicationDbContext _context;
        private GamespaceRepository _repository;

        public GamespaceController(ApplicationDbContext context, GamespaceRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new GamespaceListViewModel();
            var gamespaceList = from g in _context.Gamespaces 
                                join gs in _context.Characters 
                                on g.Id equals gs.GamespaceId
                                where gs.CharacterId == userId
                                select g;
            foreach (var gamespace in gamespaceList.ToList())
            {                
                var character = _context.Characters.SingleOrDefault(c => c.CharacterId == userId && c.GamespaceId == gamespace.Id);
                var gamespaceWithChar = new GamespaceWithCharacter
                {
                    Gamespace = Mapper.Map<GamespaceDto>(gamespace),
                    Character = Mapper.Map<GamespaceCharDto>(character)
                };
                viewModel.Gamespaces.Add(gamespaceWithChar);
            }
            return View(viewModel);
        }
        [Route("Gamespace/Create")]
        public ActionResult Create()
        {
            var viewModel = new GamespaceFormViewModel();
            viewModel.GamespaceProps = new GamespacePropsViewModel();
            viewModel.Gamespace = new GamespaceDto();
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GamespaceFormViewModel form)
        {
            var gamespaceDto = form.Gamespace; 
            if (!ModelState.IsValid)
                return View("Form", form);

            if(!_context.Gamespaces.Any(g=>g.Id == gamespaceDto.Id))
            {
                gamespaceDto.Id = _repository.Create(gamespaceDto, User.Identity.GetUserId());
            }
            else
            {
                _repository.Update(gamespaceDto);
            }
            
            return RedirectToAction("Get", "Gamespace", new {id = gamespaceDto.Id});
        }
        [Route("Gamespace/Edit")]
        public ActionResult Edit(int id)
        {
            var viewModel = new GamespaceFormViewModel();
            viewModel.GamespaceProps = _repository.GetViewModel(id, User.Identity.GetUserId());

            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            if (gamespace == null)
                return HttpNotFound();
            viewModel.Gamespace = Mapper.Map<Gamespace, GamespaceDto>(gamespace);
            return View("Form", viewModel);
        }
        [Route("Gamespace/Delete")]
        public ActionResult Delete(int id)
        {
            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            if (gamespace == null)
                return HttpNotFound();
            _context.Gamespaces.Remove(gamespace);
            _context.SaveChanges();
            return RedirectToAction("Index", "Gamespace");
        }
        [Route("Gamespace/Get")]
        public ActionResult Get(int id)
        {
            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            if (gamespace == null)
                return HttpNotFound();
            var viewModel = _repository.GetViewModel(id, User.Identity.GetUserId());
            return View("Get",  viewModel);
        }
        [Route("Gamespace/Leave")]
        public ActionResult Leave(int gamespaceId)
        {
            var userId = User.Identity.GetUserId();
            var gamespaceCharacter = _context.Characters.SingleOrDefault(gs => gs.GamespaceId == gamespaceId && gs.CharacterId == userId);
            if(gamespaceCharacter == null)
                return HttpNotFound();
            _repository.Leave(gamespaceCharacter);
            return RedirectToAction("Index", "Gamespace");
        }        
    }
}