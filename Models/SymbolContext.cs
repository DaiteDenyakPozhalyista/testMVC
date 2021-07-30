using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class SymbolContext : DbContext
    {
        public DbSet<Symbol> symbols { get; set; }
        public DbSet<HistoryMessage> historyMessages { get; set; }
    }
    public class SymbolDbInitializer : DropCreateDatabaseAlways<SymbolContext>
    {
        protected override void Seed(SymbolContext context)
        {
            context.symbols.Add(new Symbol { oldSymbol = "а", newSymbol = "н"});
            context.symbols.Add(new Symbol { oldSymbol = "б", newSymbol = "к"});
            context.symbols.Add(new Symbol { oldSymbol = "в", newSymbol = "ы"});

            base.Seed(context);
        }
    }
}