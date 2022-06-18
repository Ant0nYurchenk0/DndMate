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
using DndMate.WebApp.ViewModels;

namespace DndMate.WebApp.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private ApplicationDbContext _context;

        // GET: Notifications
        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var notifications = _context.Notifications.Where(n => n.UserEmail == User.Identity.Name)
                .ToList()
                .Select(n => Mapper.Map<Notification, NotificationDto>(n));
            return View(notifications);
        }
        public ActionResult Submit(GamespacePropsViewModel form)
        {
            var notificationDto = form.Notification;

            if (!ModelState.IsValid)
                return RedirectToAction("Get", "Gamespace", new { id = notificationDto.GamespaceId });

            var userId = _context.Users.Single(u=>u.Email == notificationDto.UserEmail).Id;

            if (_context.Characters.Any(gs => gs.GamespaceId == notificationDto.GamespaceId && gs.CharacterId == userId))
                return RedirectToAction("Get", "Gamespace", new { id = notificationDto.GamespaceId });

            if (_context.Notifications.Any(n => n.UserEmail == notificationDto.UserEmail && n.GamespaceId == notificationDto.GamespaceId))
                return RedirectToAction("Get", "Gamespace", new { id = notificationDto.GamespaceId });

            var notification = Mapper.Map<NotificationDto, Notification>(notificationDto);
            notification.GamespaceName = _context.Gamespaces.SingleOrDefault(n => n.Id == notification.GamespaceId).Name;
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return RedirectToAction("Get", "Gamespace", new { id = notification.GamespaceId });
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
                return RedirectToAction("Deny", "Notifications", new { id = id });
            return RedirectToAction("Create", "Characters", new { charId = userId, gamespaceId = notification.GamespaceId });
        }
    }
}