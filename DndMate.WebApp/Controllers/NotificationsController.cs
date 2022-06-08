using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DndMate.WebApp.Enums;

namespace DndMate.WebApp.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private ApplicationDbContext _context;

        // GET: Notifications
        public NotificationsController( ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var notifications = _context.Notifications.Where(n=>n.UserEmail == User.Identity.Name)
                .ToList()
                .Select(n=>Mapper.Map<Notification, NotificationDto>(n)); 
            return View(notifications);
        }
        public ActionResult Submit(NotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
                return View("Form",  notificationDto);
            var notification = Mapper.Map<NotificationDto, Notification>(notificationDto);
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return RedirectToAction("Get", "Gamespace", new {id=notification.GamespaceId});
        }
        public ActionResult Create(int gamespaceId)
        {
            var notificationDto = new NotificationDto();
            notificationDto.GamespaceId = gamespaceId;
            return View("Form", notificationDto);
        }
        public ActionResult Deny(int id)
        {
            var notification = _context.Notifications.SingleOrDefault(n => n.Id == id);
            if (notification == null)
                return HttpNotFound();
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return RedirectToAction("Index", "Notifications");
        }
        public ActionResult Accept(int id)
        {
            var notification = _context.Notifications.SingleOrDefault(n => n.Id == id);
            var userId = User.Identity.GetUserId();
            if (notification == null)
                return HttpNotFound();
            if (_context.Characters.Any(gs => gs.GamespaceId == notification.GamespaceId && gs.CharacterId == userId))
                return RedirectToAction("Deny", "Notifications");
            var gamespaceChar = new GamespaceChar();
            gamespaceChar.CharacterId = userId;
            gamespaceChar.GamespaceId = notification.GamespaceId;
            gamespaceChar.Role = Role.Player;
            _context.Characters.Add(gamespaceChar);
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return RedirectToAction("Index", "Notifications");
        }
    }
}