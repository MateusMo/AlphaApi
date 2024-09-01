using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain;

namespace Services.Data.Migrations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.RecoverAccessGuid)
                .IsRequired()
                .HasColumnName("RecoverAccessGuid")
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasMaxLength(255);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Photo)
                .IsRequired()
                .HasColumnName("Photo")
                .HasColumnType("int");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("smallint");

            builder.Property(x => x.IsPremium)
                .IsRequired()
                .HasColumnName("IsPremium")
                .HasColumnType("smallint");

            builder.HasMany(x => x.LinkTrees)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
