using Microsoft.EntityFrameworkCore;

namespace KafkaSaver.Database;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=mydatabase; Username=user; Password=password");
    
    public DbSet<MessageModel> Messages { get; set; }
}