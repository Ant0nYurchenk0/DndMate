using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
using DndMate.WebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;
        private GamespaceRepository _gamespaceRepository;

        // GET: Items
        public ItemsController(ApplicationDbContext context, GamespaceRepository gamespaceRepository)
        {
            _context = context;
            _gamespaceRepository = gamespaceRepository;
        }
        public ActionResult Index(int gamespaceId)
        {
            var userId = User.Identity.GetUserId();
            var character = _context.Characters.SingleOrDefault(c => c.CharacterId == userId && c.GamespaceId == gamespaceId);
            if (character == null)
                return HttpNotFound();
            var viewModel = new ItemListViewModel();
            viewModel.MyItems = _context.CharacterItems.Include(c=>c.Item).Where(c => c.CharacterId == character.Id).ToList();
            viewModel.AllItems = _context.Items.Where(c => c.GamespaceId == character.GamespaceId).ToList().Select(c=>Mapper.Map<ItemDto>(c));
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(character.GamespaceId, character.CharacterId);
            return View(viewModel);
        }
        [Route("Items/Create")]
        public ActionResult Create(int gamespaceId)
        {
            var viewModel = new ItemFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
            viewModel.Item = new ItemDto();
            viewModel.Item.GamespaceId = gamespaceId;
            return View("Form", viewModel);
        }
        [Route("Items/Delete")]
        public ActionResult Delete(int id)
        {
            var Item = _context.Items.SingleOrDefault(s => s.Id == id);
            if (Item == null)
                return HttpNotFound();
            var gamespaceId = Item.GamespaceId;
            _context.Items.Remove(Item);
            foreach (var charItem in _context.CharacterItems.Where(cs => cs.ItemId == id))
                _context.CharacterItems.Remove(charItem);
            _context.SaveChanges();
            return RedirectToAction("Index", "Items", new { gamespaceId = gamespaceId });
        }
        [Route("Items/Edit")]
        public ActionResult Edit(int id)
        {
            var Item = _context.Items.SingleOrDefault(s => s.Id == id);
            if (Item == null)
                return HttpNotFound();
            var ItemDto = Mapper.Map<Item, ItemDto>(Item);
            var viewModel = new ItemFormViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(ItemDto.GamespaceId, User.Identity.GetUserId());
            viewModel.Item = ItemDto;
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ItemFormViewModel form)
        {
            var itemDto = form.Item;
            if (!ModelState.IsValid)
            {
                var viewModel = new ItemFormViewModel();
                viewModel.Gamespace = _gamespaceRepository.GetViewModel(itemDto.GamespaceId, User.Identity.GetUserId());
                viewModel.Item = itemDto;
                return View("Form", viewModel);
            }

            if (!_context.Items.Any(s => s.Id == itemDto.Id))
            {
                _context.Items.Add(Mapper.Map<Item>(itemDto));
            }
            else
            {
                var ItemInDb = _context.Items.SingleOrDefault(s => s.Id == itemDto.Id);
                Mapper.Map(itemDto, ItemInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Items", new { gamespaceId = itemDto.GamespaceId });
        }
        public ActionResult AssignItem(int itemId, int charId)
        {            
            var charItem = _context.CharacterItems.SingleOrDefault(i=>i.ItemId == itemId&& i.CharacterId == charId);
            if (charItem != null)
                charItem.Quantity++;
            else
            {
                charItem = new GamespaceCharacterItems();
                charItem.CharacterId = charId;
                charItem.ItemId = itemId;
                charItem.Quantity = 1;
                _context.CharacterItems.Add(charItem);
            }
            var item = _context.Items.Single(i => i.Id == itemId);
            _context.SaveChanges();
            return RedirectToAction("Index", "Items", new { gamespaceId = item.GamespaceId });

        }
        public ActionResult PassItem(int itemId, int recepientId, int charId)
        {
            var charItem = _context.CharacterItems.SingleOrDefault(i => i.ItemId == itemId && i.CharacterId == charId);
            if (charItem == null)
                return HttpNotFound();
            charItem.Quantity--;
            if (charItem.Quantity <= 0)
                _context.CharacterItems.Remove(charItem);
            AssignItem(itemId, recepientId);
            
            var item = _context.Items.Single(i => i.Id == itemId);
            _context.SaveChanges();
            return RedirectToAction("Index", "Items", new { gamespaceId = item.GamespaceId });
        }
    }
}