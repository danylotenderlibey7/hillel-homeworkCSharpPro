
using Microsoft.EntityFrameworkCore;
using Notes_Homework_11._1.Models;

namespace Notes_Homework_11._1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
