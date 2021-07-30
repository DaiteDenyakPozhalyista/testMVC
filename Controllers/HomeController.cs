using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        SymbolContext db = new SymbolContext();
        [HttpGet]
        public ActionResult Index()
        {
            var messages = db.historyMessages;
            ViewBag.Messages = messages;
            return View();
        }
        [HttpPost]
        public string Index(HistoryMessage mes)
        {
            mes.Date = DateTime.Now;
            mes.newMessage = Convertation(mes);
            db.historyMessages.Add(mes);
            db.SaveChanges();
            return "Зашифрованное сообщение: " + mes.newMessage;

        }
        private string Convertation(HistoryMessage mes)
        {
            string message = mes.Message;
            char[] symbols = message.ToCharArray();
            var convert = db.symbols.ToList();
            for (int j = 0; j < symbols.Count(); j++)
            {
                for (int i = 0; i < convert.Count; i++)
                {
                    if (symbols[j] == Convert.ToChar(convert[i].oldSymbol))
                    {
                        symbols[j] = Convert.ToChar(convert[i].newSymbol);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach(char s in symbols)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }
}