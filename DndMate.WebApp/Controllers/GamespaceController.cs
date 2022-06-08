using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
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
            var gamespaceList = from g in _context.Gamespaces 
                                join gs in _context.Characters 
                                on g.Id equals gs.GamespaceId
                                where gs.CharacterId == userId
                                select g;                                           
            return View(gamespaceList.ToList().Select(n => Mapper.Map<Gamespace, GamespaceDto>(n)));
        }
        [Route("Gamespace/Create")]
        public ActionResult Create()
        {
            return View("Form", new GamespaceDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GamespaceDto gamespaceDto)
        {
            if (!ModelState.IsValid)
                return View("Form", gamespaceDto);

            if(!_context.Gamespaces.Any(g=>g.Id == gamespaceDto.Id))
            {
                _repository.Create(gamespaceDto, User.Identity.GetUserId());
            }
            else
            {
                _repository.Update(gamespaceDto);
            }
            
            return RedirectToAction("Index", "Gamespace");
        }
        [Route("Gamespace/Edit")]
        public ActionResult Edit(int id)
        {
            var gamespace = _context.Gamespaces.SingleOrDefault(g => g.Id == id);
            if (gamespace == null)
                return HttpNotFound();
            var gamespaceDto = Mapper.Map<Gamespace, GamespaceDto>(gamespace);
            return View("Form", gamespaceDto);
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
            var gamespaceDto = Mapper.Map<Gamespace, GamespaceDto>(gamespace);
            return View("Get",  gamespaceDto);
        }
        [Route("Gamespace/Leave")]
        public ActionResult Leave(string userId, int gamespaceId)
        {
            var gamespaceCharacter = _context.Characters.SingleOrDefault(gs => gs.GamespaceId == gamespaceId && gs.CharacterId == userId);
            if(gamespaceCharacter == null)
                return HttpNotFound();
            _repository.Leave(gamespaceCharacter);
            return RedirectToAction("Index", "Gamespace");
        }        
    }
}