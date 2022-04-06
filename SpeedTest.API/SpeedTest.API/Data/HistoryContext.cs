using Microsoft.EntityFrameworkCore;
using SpeedTest.API.Entities;

namespace SpeedTest.API.Data
{
    public class HistoryContext:DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }

        public DbSet<History> Histories { get; set; }
    }
}