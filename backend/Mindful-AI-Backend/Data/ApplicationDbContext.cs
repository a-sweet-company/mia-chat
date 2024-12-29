using Microsoft.EntityFrameworkCore;
using Mindful_AI_Backend.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<ChatHistory> ChatsHistories { get; set; }
    public DbSet<Ai> Ais { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageUser> MessageUsers { get; set; }
    public DbSet<MessageAi> MessageAis { get; set; }



    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ChatHistory>()
    //        .HasOne(ch => ch.User)
    //        .WithMany(u => u.ChatHistories)
    //        .HasForeignKey(ch => ch.UserId);
    //}

}


