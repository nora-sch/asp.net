using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace TP_mod5_CHATS.Controllers
{
    public class ChatController : Controller
    {

        private static List<Chat> chats;
        public List<Chat> Chats => chats ?? (chats = Chat.GetMeuteDeChats());
        // GET: Chat
        public ActionResult Index()
        {
            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = chats.FirstOrDefault(x => x.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            return RedirectToAction(nameof(Index));
        }     

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = chats.FirstOrDefault(x => x.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = chats.FirstOrDefault(x => x.Id == id);
                chats.Remove(chat);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
