using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class HistoryMessage 
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string newMessage { get; set; }
        public DateTime Date { get; set; }
    }
}