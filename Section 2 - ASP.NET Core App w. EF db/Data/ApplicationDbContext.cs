using Diary.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Table DiaryEntries (har alle properties fra Model DiaryEntry, som kolonner)
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        // modelbuilder metode
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelbuilder bruges til at sede data direkte i databasen
            modelBuilder.Entity<DiaryEntry>().HasData(

                new DiaryEntry { 
                    Id= 1, 
                    Title="Went hiking", 
                    Content="Went hiking with Joe!",
                    Created=DateTime.Now},                
                new DiaryEntry { 
                    Id= 2, 
                    Title="Went shopping", 
                    Content="Went shopping with Joe!",
                    Created=DateTime.Now},
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Went diving",
                    Content = "Went diving with Joe!",
                    Created = DateTime.Now
                }
                );
        }
    }
}
