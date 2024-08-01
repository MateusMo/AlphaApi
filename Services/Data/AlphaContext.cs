using Microsoft.EntityFrameworkCore;
using Services.Data.Migrations;
using Services.Domain;

namespace Services.Data
{
    public class AlphaContext : DbContext
    {
        public AlphaContext(DbContextOptions<AlphaContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<LinkTree> LinkTree { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Ranking> MyProperty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LinkMap());
            modelBuilder.ApplyConfiguration(new LinkTreeMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RankingMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
